namespace DeduplicationService.Tests
{
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Given_DeduplicationService
    {
        [TestClass]
        public class When_Deduplicate_Invoked
        {
            private IList<ComplexType> operand;

            private IList<ComplexType> firstOperator;

            private IList<ComplexType> secondOperator;

            private IDeduplicationService deduplicationService;

            [TestInitialize]
            public void Setup()
            {
                this.deduplicationService = new DeduplicationService();

                this.operand = new List<ComplexType>
                    {
                        new ComplexType { Id = 1, Title = "First" },
                        new ComplexType { Id = 2, Title = "Second" },
                        new ComplexType { Id = 3, Title = "Third" },
                        new ComplexType { Id = 4, Title = "Fourth" },
                        new ComplexType { Id = 5, Title = "Fifth" }
                    };

                this.firstOperator = new List<ComplexType>
                    {
                        new ComplexType { Id = 1, Title = "First" },
                        new ComplexType { Id = 2, Title = "Second" },
                    };

                this.secondOperator = new List<ComplexType>
                    {
                       new ComplexType { Id = 4, Title = "Fourth" },
                       new ComplexType { Id = 5, Title = "Fifth" }
                    };
            }

            [TestMethod]
            public void Then_Should_Return_Deduped_Collection_With_Explicit_Func_Comparison()
            {
                var deduped = this.deduplicationService.Deduplicate(this.operand, (x, y) => x.Id == y.Id, this.firstOperator, this.secondOperator);

                Assert.IsTrue(deduped.Count() == 1);
            }

            [TestMethod]
            public void Then_Should_Return_Deduped_Collection_For_Complex_Types_With_Implicit_Func_Comparison()
            {
                var deduped = this.deduplicationService.Deduplicate(this.operand, x => x.Id, this.firstOperator, this.secondOperator);

                Assert.IsTrue(deduped.Count() == 1);
            }

            [TestMethod]
            public void Then_Should_Return_Deduped_Collection_When_Using_ComplexType_Type_With_Default_Comparer()
            {
                var deduped = this.deduplicationService.Deduplicate(this.operand, this.firstOperator, this.secondOperator);

                Assert.IsTrue(deduped.Count() == 1);
            }
        }
    }
}
