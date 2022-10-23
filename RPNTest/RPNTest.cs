using NUnit.Framework;
using System;
using RPNCalulator;
using System.Data;

namespace RPNTest {
	[TestFixture]
	public class RPNTest {
		private RPN _sut;
		[SetUp]
		public void Setup() {
			_sut = new RPN();
		}

		[Test]
		public void CheckIfTestWorks() {
			Assert.Pass();
		}

		[Test]
		public void CheckIfCanCreateSut() {
			Assert.That(_sut, Is.Not.Null);
		}

		[Test]
		public void SingleDigitOneInputOneReturn() {
			var result = _sut.EvalRPN("1");
			Assert.That(result, Is.EqualTo(1));
		}

		[Test]
		public void SingleDigitOtherThenOneInputNumberReturn() {
			var result = _sut.EvalRPN("2");
			Assert.That(result, Is.EqualTo(2));
		}

		[Test]
		public void TwoDigitsNumberInputNumberReturn() {
			var result = _sut.EvalRPN("12");
			Assert.That(result, Is.EqualTo(12));
		}

		[Test]
		public void TwoNumbersGivenWithoutOperator_ThrowsExcepton() {
			Assert.Throws<InvalidOperationException>(() => _sut.EvalRPN("1 2"));
		}

		[Test]
		public void OperatorPlus_AddingTwoNumbers_ReturnCorrectResult() {
			var result = _sut.EvalRPN("1 2 +");
			Assert.That(result, Is.EqualTo(3));
		}

		[Test]
		public void OperatorTimes_AddingTwoNumbers_ReturnCorrectResult() {
			var result = _sut.EvalRPN("2 2 *");
			Assert.That(result, Is.EqualTo(4));
		}

		[Test]
		public void OperatorMinus_SubstractingTwoNumbers_ReturnCorrectResult() {
			var result = _sut.EvalRPN("2 1 -");
			Assert.That(result, Is.EqualTo(1));
		}

		[Test]
		public void ComplexExpression() {
			var result = _sut.EvalRPN("15 7 1 1 + - / 3 * 2 1 1 + + -");
			Assert.That(result, Is.EqualTo(5));
		}

        [Test]
        public void ConvertBinaryToDecimal() {
            var result = _sut.EvalRPN("B101");
            Assert.That(result, Is.EqualTo(5));
        }
        [Test]
        public void ConvertToDecimal() {
            var result = _sut.EvalRPN("D10");
            Assert.That(result, Is.EqualTo(10));
        }
        [Test]
        public void ConvertHexToDecimal() {
            var result = _sut.EvalRPN("#AB");
            Assert.That(result, Is.EqualTo(171));
        }
        [Test]
        public void TestExpression() {
            var result = _sut.EvalRPN("#BA D14 + B100 *");
            Assert.That(result, Is.EqualTo(800));
        }
        [Test]
        public void TestFactorial()
        {
            var result = _sut.EvalRPN("5 !");
            Assert.That(result, Is.EqualTo(120));
        }
        [Test]
        public void TestExpressionWithFactorial()
        {
            var result = _sut.EvalRPN("2 3 + 5 ! *");
            Assert.That(result, Is.EqualTo(600));
        }
        [Test]
        public void TestInvalidOperation()
        {
			Assert.Throws<InvalidOperationException>(delegate { _sut.EvalRPN("1 +"); });
        }
        [Test]
        public void OneElementTest()
        {
            Assert.Throws<ArgumentOutOfRangeException>(delegate { _sut.EvalRPN("#"); });
        }
        [Test]
        public void TestDivideByZero()
        {
            Assert.Throws<DivideByZeroException>(delegate { _sut.EvalRPN("5 0 /"); });
        }
        [Test]
        public void TestDivideTwoNumbers()
        {
            var result = _sut.EvalRPN("4 2 /");
            Assert.That(result, Is.EqualTo(2));
        }
        [Test]
        public void TestInvalidExpression()
        {
            Assert.Throws<InvalidOperationException>(delegate { _sut.EvalRPN("5 2 + _"); });
        }
        [Test]
        public void OtherElementTest()
        {
            Assert.Throws<InvalidOperationException>(delegate { _sut.EvalRPN("%"); });
        }
    }
}