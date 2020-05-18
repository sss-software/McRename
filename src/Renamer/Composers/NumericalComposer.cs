﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Renamer.Composers
{
    public class NumericalComposer : ICompose
    {
        private readonly char Separator;

        public NumericalComposer()
        {
            Separator = Path.DirectorySeparatorChar;
        }

        public Dictionary<string, string> Rename(ComposeInstructions instructions)
        {
            var proposal = new Dictionary<string, string>();

            instructions.Files.Sort((x, y) => DateTime.Compare(x.CreationDateTime, y.CreationDateTime));

            for (int i = 0; i < instructions.Files.Count; i++)
            {
                var path = instructions.Files[i].Path;
                var directory = Path.GetDirectoryName(path);
                var extension = Path.GetExtension(path);

                string newPath = $"{directory}{Separator}{i + 1}{extension}";

                proposal.Add(path, newPath);
            }

            return proposal;
        }
    }
}