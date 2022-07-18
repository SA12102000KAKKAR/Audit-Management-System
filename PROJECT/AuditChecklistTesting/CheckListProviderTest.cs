using AuditChecklistModule.Models;
using AuditChecklistModule.Providers;
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
    public class CheckListProviderTest
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
            CheckListProvider cp = new CheckListProvider(mock.Object);
            List<Questions> result = cp.QuestionsProvider(type);
            Assert.AreEqual(3, result.Count);
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
                CheckListProvider cp = new CheckListProvider(mock.Object);
                List<Questions> result = cp.QuestionsProvider(type);
                Assert.AreEqual(0, result.Count);
            }
            catch (Exception e)
            {
                Assert.AreEqual("Object reference not set to an instance of an object.", e.Message);
            }

        }
    }
}
