using System;
using System.Collections.Generic;
using System.Linq;
using LibGit2Sharp;

namespace libgit2sharp_demo
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var repo = new Repository("C:/Users/JONATWEI/Source/demo/gitrep_demo/.git"))
            {
                var newestCommit = repo.Commits.First();
                var initCommitId = "3ee343361b2202d0dc20c92e0455cfa2c65112dc";
                var initCommit = repo.Commits.FirstOrDefault(c => c.Sha == initCommitId);

                var changes = repo.Diff.Compare<TreeChanges>(initCommit.Tree, newestCommit.Tree);

                Console.WriteLine($"Added count: {changes.Added.Count()}");
                Console.WriteLine($"Modified count: {changes.Modified.Count()}");

                var changedFiles = new List<string>();
                changedFiles.AddRange(changes.Added.Select(c => c.Path).ToList());
                changedFiles.AddRange(changes.Modified.Select(c => c.Path).ToList());

                foreach (var item in changedFiles)
                {
                    Console.WriteLine($"Path: {item}");
                }
            }
        }
    }
}
