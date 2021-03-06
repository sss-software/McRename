﻿using System.Collections.Generic;
using Renamer.Interfaces;

namespace Renamer
{
    public class RenameOrchestrator : IOrchestrate
    {
        private readonly IValidateComposeInstructions inputValidator;
        private readonly IBuildComposer composerFactory;
        private ICompose composer;

        public RenameOrchestrator(IValidateComposeInstructions inputValidator, IBuildComposer composerFactory)
        {
            this.inputValidator = inputValidator;
            this.composerFactory = composerFactory;
        }

        public Dictionary<string, string> Orchestrate(ComposeInstructions instructions)
        {
            var composition = new Dictionary<string, string>();

            var validation = inputValidator.Validate(ref instructions);

            if (!validation.isValid)
            {
                return composition;
            }

            composer = composerFactory.Build(instructions.Mode);
            
            composition = composer.Compose(instructions);

            return composition;
        }
    }
}
