﻿using System.Collections.Generic;
using NSubstitute;
using Renamer;
using Renamer.Interfaces;
using Xunit;

namespace RenamerTests
{
    public class RenameOrchestratorTests
    {
        private readonly IValidateComposeInstructions inputValidator;
        private readonly IBuildComposer composerFactory;
        private readonly RenameOrchestrator subject;
        private ComposeInstructions instructions = new ComposeInstructions(
            ComposeMode.Unknown,
            new List<FileInformation>()
            );

        public RenameOrchestratorTests()
        {
            inputValidator = Substitute.For<IValidateComposeInstructions>();
            composerFactory = Substitute.For<IBuildComposer>();
            subject = new RenameOrchestrator(inputValidator, composerFactory);
        }

        [Fact]
        public void WhenOrchestrating_ItShouldValidateInputFirst()
        {
            _ = subject.Orchestrate(instructions);

            inputValidator.Received(1).Validate(ref instructions);
        }
        
        [Fact]
        public void WhenOrchestratingValidInput_ItShouldComposeNext()
        {
            inputValidator.Validate(ref instructions).ReturnsForAnyArgs((true, ""));
            _ = subject.Orchestrate(instructions);

            inputValidator.Received(1).Validate(ref instructions);
            composerFactory.Received(1).Build(instructions.Mode);
        }

        [Fact]
        public void WhenOrchestratingInvalidInput_ItShouldNotCompose()
        {

        }

        [Fact]
        public void WhenOrchestrating_ItShouldValidateOutputLast()
        {

        }
    }
}
