using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using Newtonsoft.Json;

namespace MongoDbDemo
{
    class Program
    {
        private static Guid _johnUserId = new Guid("7742c10a-7c45-43ae-b5c6-339172bbe9d4");

        static void Main(string[] args)
        {
            DefineMappings();

            var database = GetDatabase();
            var identityUsers = database.GetCollection<IdentityUser>("MyUsers");
            var users = database.GetCollection<User>("MyUsers");
            var qaUsers = database.GetCollection<QaUser>("MyUsers");

            //CreateUsers(identityUsers);

            var identityUserById = identityUsers.Find(u => u.Id == _johnUserId).FirstOrDefault();
            Write(identityUserById);

            var qaUser = qaUsers.Find(u => u.UserName == "john").FirstOrDefault();
            Write(qaUser);

            qaUser.Reputation += 1.0f;
            qaUser.Activities.Add(new QaUserActivity{UserId = qaUser.Id, ActivityDefinition = "Tested", Time = DateTime.Now});

            //qaUsers.UpdateOne(Builders<QaUser>.Filter.Eq(u => u.Id, qaUser.Id), ConvertToBsonDoc(qaUser));
            qaUsers.ReplaceOne(Builders<QaUser>.Filter.Eq(u => u.Id, qaUser.Id), qaUser);

            Console.ReadLine();
        }

        private static void Write(object obj)
        {
            Console.WriteLine(obj);
            Console.WriteLine("-----------------------------------------------------------------------------------");
        }

        private static IMongoDatabase GetDatabase()
        {
            return new MongoClient().GetDatabase("MongoDbDemo");
        }

        private static void DefineMappings()
        {
            BsonClassMap.RegisterClassMap<User>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<IdentityUser>(map =>
            {
                map.AutoMap();
                map.SetIgnoreExtraElements(true);
            });

            BsonClassMap.RegisterClassMap<QaUser>(map =>
            {
                map.AutoMap();
                //map.SetIgnoreExtraElements(true);
                map.MapExtraElementsProperty(u => u.ExtraProperties);
            });
        }

        private static void CreateUsers(IMongoCollection<IdentityUser> identityUsers)
        {
            identityUsers.InsertOne(new IdentityUser(_johnUserId, "john", "123")
            {
                Roles =
                {
                    new IdentityUserRole {RoleName = "admin", UserId = _johnUserId},
                    new IdentityUserRole {RoleName = "supporter", UserId = _johnUserId}
                }
            });

            identityUsers.InsertOne(new IdentityUser(Guid.NewGuid(), Guid.NewGuid().ToString(), "123"));
        }

        private static BsonDocument ConvertToBsonDoc(QaUser qaUser)
        {
            var bsonObject = BsonDocument.Parse(JsonConvert.SerializeObject(qaUser));
            bsonObject.Remove(nameof(QaUser.Id));
            bsonObject.Remove(nameof(QaUser.ExtraProperties));
            var bson = new BsonDocument { { "$set", bsonObject } };
            return bson;
        }
    }
}
