﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using calculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator.Tests
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //判断计数是否准确
            Assert.AreEqual(Program.Add(5), 5);
        }

        [TestMethod()]
        public void AutoTest()
        {
            //判断是否能成功生成一个运算表达式的字符串
            Assert.AreEqual(Program.Auto(2, 3, 0, 100), true);
        }

        [TestMethod()]
        public void SaveTest()
        {
            //判断结果为负数是否舍去
            Assert.IsNull(Program.Save("3-2-3", "3.00-2.00-3.00"));
            //判断结果为小数是否舍去
            //两个除法相加减会导致过程有小数但结果为整数的情况，
            //以及除号位置导致的小数问题已经在代码中处理。
            Assert.IsNull(Program.Save("3/5+2", "3.00/5.00+2.00"));
            //判断出现除零错误是否舍去
            Assert.IsNull(Program.Save("1/0-1","1.00/0.00-1.00"));
            //判断符合要求并保存的算式的结果是否正确
            Assert.AreEqual(Program.Save("2+8/2", "2.00+8.00/2.00"), (6).ToString());
        }
    }
}