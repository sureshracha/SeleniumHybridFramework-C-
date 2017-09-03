using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace efrAutomation.TestUtils
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true,Inherited = true)]
    public class TestUserStory : Attribute
    {
        public TestUserStory(string testUserStory) { }
    }

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true,Inherited =true)]
    public class TestCaseID : Attribute
    {
        public TestCaseID(string testCaseName) { }
    }

}
