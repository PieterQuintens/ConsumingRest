using System;
using System.Collections.Generic;
using System.Text;

namespace TestApp.Models
{
    class MockRepository
    {
        public IEnumerable<TestModel> GetModelList()
        {
            return new List<TestModel>
            {
                new TestModel{ Title="test1"},
                new TestModel{ Title="test2"},
                new TestModel{ Title="test3"},
                new TestModel{ Title="test4"},
                new TestModel{ Title="test5"}
            };
        }
    }
}
