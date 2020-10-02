﻿using Something.Domain;
using Something.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Something.Application
{
    public class SomethingElseUpdateInteractor : ISomethingElseUpdateInteractor
    {
        private readonly ISomethingFactory somethingFactory;
        private ISomethingElseFactory somethingElseFactory;
        private ISomethingElsePersistence persistence;

        public SomethingElseUpdateInteractor(ISomethingFactory somethingFactory, ISomethingElseFactory somethingElseFactory, ISomethingElsePersistence persistence)
        {
            this.somethingFactory = somethingFactory;
            this.somethingElseFactory = somethingElseFactory;
            this.persistence = persistence;
        }

        public Domain.Models.SomethingElse UpdateSomethingElseAddSomething(int id, string name)
        {
            var something = somethingFactory.Create(name);
            return persistence.UpdateSomethingElseByIdAddSomething(id, something);
        }
    }
}