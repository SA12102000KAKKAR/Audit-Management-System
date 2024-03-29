﻿using AuditChecklistModule.Models;
using AuditChecklistModule.Repository;

using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuditChecklistTesting
{
    public class CheckListRepoTest
    {
        List<Questions> l1 = new List<Questions>();
        List<Questions> l2 = null;
        [SetUp]
        public void setup()
        {

            l1 = new List<Questions>()
            {
                new Questions
                {
                    QuestionNo=1,
                    Question="Have all Change requests followed SDLC before PROD move?"
                },
                new Questions
                {
                    QuestionNo=2,
                    Question="Have all Change requests been approved by the application owner?"
                },
                new Questions
                {
                    QuestionNo=3,
                    Question="For a major change, was there a database backup taken before and after PROD move?"
                },
                new Questions
                {
                    QuestionNo=4,
                    Question="Has the application owner approval obtained while adding a user to the system?"
                },
                new Questions
                {
                    QuestionNo=5,
                    Question="Is data deletion from the system done with application owner approval?"
                }


            };
        }

        [TestCase("Internal")]
        [TestCase("SOX")]
        public void QuestionsProvider_ValidInput_OkRequest(string type)
        {

            Mock<ICheckListRepo> mock = new Mock<ICheckListRepo>();
            mock.Setup(p => p.GetQuestions(type)).Returns(l1);
            CheckListRepo cp = new CheckListRepo();
            List<Questions> result = cp.GetQuestions(type);
            Assert.AreEqual(l1.Count, result.Count);

        }

        [TestCase("Internalab")]
        [TestCase("SOXab")]
        public void GetQuestions_InvalidInput_ReturnBadRequest(string a)
        {
            try
            {
                string type = null;
                Mock<ICheckListRepo> mock = new Mock<ICheckListRepo>();
                mock.Setup(p => p.GetQuestions(type)).Returns(l2);
                CheckListRepo cp = new CheckListRepo();
                List<Questions> result = cp.GetQuestions(type);
                Assert.AreEqual(l2.Count, result.Count);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }
        }
    }
}
