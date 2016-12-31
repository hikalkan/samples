using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using DddDemo.Issues.Comments;
using DddDemo.Users;
using JetBrains.Annotations;

namespace DddDemo.Issues
{
    public class Issue //Aggregate Root
    {
        [NotNull]
        public string Id { get; protected set; }

        [NotNull]
        public string Title { get; protected set; }

        [CanBeNull]
        public string Body { get; protected set; }

        public bool IsClosed { get; protected set; }

        public bool IsLocked { get; protected set; }

        public IssueCloseReason? CloseReason { get; protected set; }

        [NotNull]
        public string CreatorUserId { get; protected set; } //No navigation property to another aggregate root!

        [CanBeNull]
        public string AssignedUserId { get; protected set; } //No navigation property to another aggregate root!

        [NotNull]
        public IReadOnlyList<IssueComment> Comments => _comments.ToImmutableList();
        protected ICollection<IssueComment> _comments { get; set; }

        protected Issue()
        {

        }

        public Issue([NotNull] string creatorUserId, [NotNull] string title, string body = null) //Can not get AssignedUserId into constructor!
        {
            Check.NotNull(creatorUserId, nameof(creatorUserId));
            Check.NotNull(title, nameof(title));

            Id = Guid.NewGuid().ToString("D");

            CreatorUserId = creatorUserId;
            Title = title;
            Body = body;

            _comments = new Collection<IssueComment>();
        }

        public void AssignTo([NotNull] User user, [NotNull] IIssueAssignmentPolicy policy)
        {
            Check.NotNull(user, nameof(user));
            Check.NotNull(policy, nameof(policy));

            policy.CheckAssignment(this, user);

            AssignedUserId = user.Id;
        }

        public void ClearAssignment()
        {
            AssignedUserId = null;
        }

        public IssueComment AddComment([NotNull] User creatorUser, [NotNull] string message)
        {
            Check.NotNull(creatorUser, nameof(creatorUser));

            if (IsLocked)
            {
                throw new IssueLockedException(Id);
            }

            var comment = new IssueComment(creatorUser.Id, message);
            _comments.Add(comment);
            return comment;
        }

        public void Close(IssueCloseReason reason)
        {
            CloseReason = reason;
            IsClosed = true;
        }

        public void ReOpen()
        {
            IsClosed = false;
            CloseReason = null;
        }

        public void Lock()
        {
            if (!IsClosed)
            {
                throw new InvalidOperationException("An open issue can not be locked. Should be closed first!");
            }

            IsLocked = true;
        }

        public void Unlock()
        {
            IsLocked = false;
        }

        public override string ToString()
        {
            return $"[Issue {Id}] {Title}";
        }
    }
}
