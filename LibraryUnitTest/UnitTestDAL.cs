using static LibraryBuisnessLogicLayer.Processor.UserProccessor;
using static LibraryDatabaseAccessLayer.SQL_DAL;
using LibraryCommon;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibraryCommon.Models;
using System.Collections.Generic;

namespace LibraryUnitTest
{
    [TestClass]
    public class UnitTestDAL
    {
        UserDTO Test = new UserDTO() {FirstName = "Bob", LastName="Ross", UserName="BobRoss", Email="TestEmail", Id=0, Role=1};
        [TestMethod]
        public void TestUserProccessorCreateUser()
        {

            int _success = CreateUser(Test);
            Assert.IsTrue(_success > 0);
        }
        [TestMethod]
        public void TestUserProccessorLoadData()
        {
            List<UserDTO> _success = LoadUsers();
            Test = _success[_success.Count-1];
            Assert.IsTrue(_success.Count > 0);
        }
        [TestMethod]
        public void TestUserProccessorDeleteData()
        {
            Assert.IsTrue(DeleteUserTest(Test));
        }
    }
}