using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bogus;
using Moq;
using AdvancedCSharpConceptsConsole.Logic;
using AdvancedCSharpConceptsConsole.Models;
using AdvancedCSharpConceptsConsole.Repositories;

namespace TestProject
{
    [TestClass]
    public class UnitTest
    {
        private Mock<IEmployeeRepository> _employeeRepositoryMock;
        private Action _action;
        private AnonymousMethod _anonymousMethod;
        private AnonymousType _anonymousType;
        private Delegates _delegates;
        private Event _event;
        private ExtensionMethod _extensionMethod;
        private Func _func;
        private LambdaExpression _lambdaExpression;
        private Linq _linq;

        [TestInitialize]
        public void Initialize()
        {
            _employeeRepositoryMock = new Mock<IEmployeeRepository>();
            
            int nextId = 1;
            var faker = new Faker<Employee>()
                .RuleFor(c => c.Id, f => nextId++)
                .RuleFor(c => c.Name, f => f.Person.FirstName)
                .RuleFor(c => c.Experience, f => f.Random.Int(1, 10));

            _employeeRepositoryMock.Setup(u => u.GetEmployees()).Returns(faker.Generate(50));

            _action = new Action(_employeeRepositoryMock.Object);
            _anonymousMethod = new AnonymousMethod(_employeeRepositoryMock.Object);
            _anonymousType = new AnonymousType(_employeeRepositoryMock.Object);
            _delegates = new Delegates(_employeeRepositoryMock.Object);
            _event = new Event(_employeeRepositoryMock.Object);
            _extensionMethod = new ExtensionMethod(_employeeRepositoryMock.Object);
            _func = new Func(_employeeRepositoryMock.Object);
            _lambdaExpression = new LambdaExpression(_employeeRepositoryMock.Object);
            _linq = new Linq(_employeeRepositoryMock.Object);
        }

        [TestMethod]
        public void TestDelegateExample()
        {
            _delegates.RunDelegateExample();
        }

        [TestMethod]
        public void TestAnonymusMethodExample()
        {
            _anonymousMethod.RunAnonymusMethodExample();
        }

        [TestMethod]
        public void TestFuncExample()
        {
            _func.RunFuncExample();
        }

        [TestMethod]
        public void TestActionExample()
        {
            _action.RunActionExample();
        }

        [TestMethod]
        public void TestEventExample()
        {
            _event.RunEventExample();
        }

        [TestMethod]
        public void TestAnonymousTypeExample()
        {
            _anonymousType.RunAnonymousTypeExample();
        }

        [TestMethod]
        public void TestLambdaExample()
        {
            _lambdaExpression.RunLambdaExample();
        }

        [TestMethod]
        public void TestRunLinqExample()
        {
            _linq.RunLinqExample();
        }

        [TestMethod]
        public void TestExtensionMethodExample()
        {
            _extensionMethod.RunExtensionMethodExample();
        }

    }
}
