using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EfCoreGlobalFilterBugDemo
{
    class Program
    {
        public static Guid? CurrentTenantId { get; set; }

        static void Main(string[] args)
        {
            DoWork();

            Console.ReadLine();
        }

        private static void DoWork()
        {
            Parallel.For(
                0, 
                32,
                new ParallelOptions {MaxDegreeOfParallelism = 16},
                i => ReadUsers().GetAwaiter().GetResult()
            );
        }

        private static async Task ReadUsers()
        {
            using (var context = new MyDbContext())
            {
                Console.WriteLine(await context.Users.FirstOrDefaultAsync(u => u.UserName == "David"));

                var users = await context.Users.ToListAsync();
                if (users.Any(u => u.TenantId != CurrentTenantId))
                {
                    throw new Exception("Unexpected TenantId!");
                }

                foreach (var user in users)
                {
                    Console.WriteLine(user);
                }
            }
        }
    }
}
