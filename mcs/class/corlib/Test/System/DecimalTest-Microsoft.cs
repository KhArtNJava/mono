// DecimalTest-Microsoft.cs - NUnit Test Cases for System.Decimal, ported
// from corefx src/System.Runtime/tests/System/Decimal.cs to NUnit
//
// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// Copyright 2015 Xamarin Inc
// 

using NUnit.Framework;
using System;
using MonoTests.Common;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Collections.Generic;

#pragma warning disable CS1718

namespace MonoTests.System
{
	[TestFixture]
	public class DecimalTestMicrosoft
	{
		[Test]
		public void TestEquals()
		{
		    // Boolean Decimal.Equals(Decimal)
		    Assert.IsTrue(Decimal.Zero.Equals(Decimal.Zero));
		    Assert.IsFalse(Decimal.Zero.Equals(Decimal.One));
		    Assert.IsTrue(Decimal.MaxValue.Equals(Decimal.MaxValue));
		    Assert.IsTrue(Decimal.MinValue.Equals(Decimal.MinValue));
		    Assert.IsFalse(Decimal.MaxValue.Equals(Decimal.MinValue));
		    Assert.IsFalse(Decimal.MinValue.Equals(Decimal.MaxValue));
		}
		
		[Test]
		public void TestEqualsDecDec()
		{
		    // Boolean Decimal.Equals(Decimal, Decimal)
		    Assert.IsTrue(Decimal.Equals(Decimal.Zero, Decimal.Zero));
		    Assert.IsFalse(Decimal.Equals(Decimal.Zero, Decimal.One));
		    Assert.IsTrue(Decimal.Equals(Decimal.MaxValue, Decimal.MaxValue));
		    Assert.IsTrue(Decimal.Equals(Decimal.MinValue, Decimal.MinValue));
		    Assert.IsFalse(Decimal.Equals(Decimal.MinValue, Decimal.MaxValue));
		    Assert.IsFalse(Decimal.Equals(Decimal.MaxValue, Decimal.MinValue));
		}
		
		[Test]
		public void TestEqualsObj()
		{
		    // Boolean Decimal.Equals(Object)
		    Assert.IsTrue(Decimal.Zero.Equals((object)Decimal.Zero));
		    Assert.IsFalse(Decimal.Zero.Equals((object)Decimal.One));
		    Assert.IsTrue(Decimal.MaxValue.Equals((object)Decimal.MaxValue));
		    Assert.IsTrue(Decimal.MinValue.Equals((object)Decimal.MinValue));
		    Assert.IsFalse(Decimal.MinValue.Equals((object)Decimal.MaxValue));
		    Assert.IsFalse(Decimal.MaxValue.Equals((object)Decimal.MinValue));
		    Assert.IsFalse(Decimal.One.Equals(null));
		    Assert.IsFalse(Decimal.One.Equals("one"));
		    Assert.IsFalse(Decimal.One.Equals((object)1));
		}
		
		[Test]
		public void Testop_Equality()
		{
		    // Boolean Decimal.op_Equality(Decimal, Decimal)
		    Assert.IsTrue(Decimal.Zero == Decimal.Zero);
		    Assert.IsFalse(Decimal.Zero == Decimal.One);
		    Assert.IsTrue(Decimal.MaxValue == Decimal.MaxValue);
		    Assert.IsTrue(Decimal.MinValue == Decimal.MinValue);
		    Assert.IsFalse(Decimal.MinValue == Decimal.MaxValue);
		    Assert.IsFalse(Decimal.MaxValue == Decimal.MinValue);
		}
		
		[Test]
		public void Testop_GreaterThan()
		{
		    // Boolean Decimal.op_GreaterThan(Decimal, Decimal)
		    Assert.IsFalse(Decimal.Zero > Decimal.Zero);
		    Assert.IsFalse(Decimal.Zero > Decimal.One);
		    Assert.IsTrue(Decimal.One > Decimal.Zero);
		    Assert.IsFalse(Decimal.MaxValue > Decimal.MaxValue);
		    Assert.IsFalse(Decimal.MinValue > Decimal.MinValue);
		    Assert.IsFalse(Decimal.MinValue > Decimal.MaxValue);
		    Assert.IsTrue(Decimal.MaxValue > Decimal.MinValue);
		}
		
		[Test]
		public void Testop_GreaterThanOrEqual()
		{
		    // Boolean Decimal.op_GreaterThanOrEqual(Decimal, Decimal)
		    Assert.IsTrue(Decimal.Zero >= Decimal.Zero);
		    Assert.IsFalse(Decimal.Zero >= Decimal.One);
		    Assert.IsTrue(Decimal.One >= Decimal.Zero);
		    Assert.IsTrue(Decimal.MaxValue >= Decimal.MaxValue);
		    Assert.IsTrue(Decimal.MinValue >= Decimal.MinValue);
		    Assert.IsFalse(Decimal.MinValue >= Decimal.MaxValue);
		    Assert.IsTrue(Decimal.MaxValue >= Decimal.MinValue);
		}
		
		[Test]
		public void Testop_Inequality()
		{
		    // Boolean Decimal.op_Inequality(Decimal, Decimal)
		    Assert.IsFalse(Decimal.Zero != Decimal.Zero);
		    Assert.IsTrue(Decimal.Zero != Decimal.One);
		    Assert.IsTrue(Decimal.One != Decimal.Zero);
		    Assert.IsFalse(Decimal.MaxValue != Decimal.MaxValue);
		    Assert.IsFalse(Decimal.MinValue != Decimal.MinValue);
		    Assert.IsTrue(Decimal.MinValue != Decimal.MaxValue);
		    Assert.IsTrue(Decimal.MaxValue != Decimal.MinValue);
		}
		
		[Test]
		public void Testop_LessThan()
		{
		    // Boolean Decimal.op_LessThan(Decimal, Decimal)
		    Assert.IsFalse(Decimal.Zero < Decimal.Zero);
		    Assert.IsTrue(Decimal.Zero < Decimal.One);
		    Assert.IsFalse(Decimal.One < Decimal.Zero);
		    Assert.IsTrue(5m < 15m);
		    decimal d5 = 5;
		    decimal d3 = 3;
		    Assert.IsFalse(d5 < d3);
		    Assert.IsFalse(Decimal.MaxValue < Decimal.MaxValue);
		    Assert.IsFalse(Decimal.MinValue < Decimal.MinValue);
		    Assert.IsTrue(Decimal.MinValue < Decimal.MaxValue);
		    Assert.IsFalse(Decimal.MaxValue < Decimal.MinValue);
		}
		
		[Test]
		public void Testop_LessThanOrEqual()
		{
		    // Boolean Decimal.op_LessThanOrEqual(Decimal, Decimal)
		    Assert.IsTrue(Decimal.Zero <= Decimal.Zero);
		    Assert.IsTrue(Decimal.Zero <= Decimal.One);
		    Assert.IsFalse(Decimal.One <= Decimal.Zero);
		    Assert.IsTrue(Decimal.MaxValue <= Decimal.MaxValue);
		    Assert.IsTrue(Decimal.MinValue <= Decimal.MinValue);
		    Assert.IsTrue(Decimal.MinValue <= Decimal.MaxValue);
		    Assert.IsFalse(Decimal.MaxValue <= Decimal.MinValue);
		}
		
		[Test]
		public void TestToByte()
		{
		    // Byte Decimal.ToByte(Decimal)
		    Assert.AreEqual(0, Decimal.ToByte(0));
		    Assert.AreEqual(1, Decimal.ToByte(1));
		    Assert.AreEqual(255, Decimal.ToByte(255));
		
		    AssertExtensions.Throws<OverflowException>(() => Decimal.ToByte(256), "Expected an overflow");
		}
		
		private void VerifyAdd<T>(Decimal d1, Decimal d2, Decimal expected = Decimal.Zero) where T : Exception
		{
		    bool expectFailure = typeof(T) != typeof(Exception);
		
		    try
		    {
		        Decimal result1 = Decimal.Add(d1, d2);
		        Decimal result2 = d1 + d2;
		
		        Assert.IsFalse(expectFailure, "Expected an exception to be thrown");
		        Assert.AreEqual(result1, result2);
		        Assert.AreEqual(expected, result1);
		    }
		    catch (T)
		    {
		        Assert.IsTrue(expectFailure, "Didn't expect an exception to be thrown");
		    }
		}
		[Test]
		public void TestAdd()
		{
		    // Decimal Decimal.Add(Decimal, Decimal)
		    // Decimal Decimal.op_Addition(Decimal, Decimal)
		    VerifyAdd<Exception>(1, 1, 2);
		    VerifyAdd<Exception>(-1, 1, 0);
		    VerifyAdd<Exception>(1, -1, 0);
		    VerifyAdd<Exception>(Decimal.MaxValue, Decimal.Zero, Decimal.MaxValue);
		    VerifyAdd<Exception>(Decimal.MinValue, Decimal.Zero, Decimal.MinValue);
		    VerifyAdd<Exception>(79228162514264337593543950330m, 5, Decimal.MaxValue);
		    VerifyAdd<Exception>(79228162514264337593543950330m, -5, 79228162514264337593543950325m);
		    VerifyAdd<Exception>(-79228162514264337593543950330m, -5, Decimal.MinValue);
		    VerifyAdd<Exception>(-79228162514264337593543950330m, 5, -79228162514264337593543950325m);
		    VerifyAdd<Exception>(1234.5678m, 0.00009m, 1234.56789m);
		    VerifyAdd<Exception>(-1234.5678m, 0.00009m, -1234.56771m);
		    VerifyAdd<Exception>(0.1111111111111111111111111111m,
		                         0.1111111111111111111111111111m,
		                         0.2222222222222222222222222222m);
		    VerifyAdd<Exception>(0.5555555555555555555555555555m,
		                         0.5555555555555555555555555555m,
		                         1.1111111111111111111111111110m);
		
		    // Exceptions
		    VerifyAdd<OverflowException>(Decimal.MaxValue, Decimal.MaxValue);
		    VerifyAdd<OverflowException>(79228162514264337593543950330m, 6);
		    VerifyAdd<OverflowException>(-79228162514264337593543950330m, -6, Decimal.MinValue);
		}

		[Test]
		public void TestCeiling()
		{
		    // Decimal Decimal.Ceiling(Decimal)
		    Assert.AreEqual(123, Decimal.Ceiling((Decimal)123));
		    Assert.AreEqual(124, Decimal.Ceiling((Decimal)123.123));
		    Assert.AreEqual(-123, Decimal.Ceiling((Decimal)(-123.123)));
		    Assert.AreEqual(124, Decimal.Ceiling((Decimal)123.567));
		    Assert.AreEqual(-123, Decimal.Ceiling((Decimal)(-123.567)));
		}
		
		private void VerifyDivide<T>(Decimal d1, Decimal d2, Decimal expected = Decimal.Zero) where T : Exception
		{
		    bool expectFailure = typeof(T) != typeof(Exception);
		
		    try
		    {
		        Decimal result1 = Decimal.Divide(d1, d2);
		        Decimal result2 = d1 / d2;
		
		        Assert.IsFalse(expectFailure, "Expected an exception to be thrown");
		        Assert.AreEqual(result1, result2);
		        Assert.AreEqual(expected, result1);
		    }
		    catch (T)
		    {
		        Assert.IsTrue(expectFailure, "Didn't expect an exception to be thrown");
		    }
		}
		[Test]
		public void TestDivide()
		{
		    // Decimal Decimal.Divide(Decimal, Decimal)
		    // Decimal Decimal.op_Division(Decimal, Decimal)
		
		    // Vanilla cases
		    VerifyDivide<Exception>(Decimal.One, Decimal.One, Decimal.One);
		    VerifyDivide<Exception>(Decimal.MaxValue, Decimal.MinValue, Decimal.MinusOne);
		    VerifyDivide<Exception>(0.9214206543486529434634231456m, Decimal.MaxValue, Decimal.Zero);
		    VerifyDivide<Exception>(38214206543486529434634231456m, 0.49214206543486529434634231456m, 77648730371625094566866001277m);
		    VerifyDivide<Exception>(-78228162514264337593543950335m, Decimal.MaxValue, -0.987378225516463811113412343m);
		    VerifyDivide<Exception>(5m + 10m, 2m, 7.5m);
		    VerifyDivide<Exception>(10m, 2m, 5m);
		
		    // Tests near MaxValue (VSWhidbey #389382)
		    VerifyDivide<Exception>(792281625142643375935439503.4m, 0.1m, 7922816251426433759354395034m);
		    VerifyDivide<Exception>(79228162514264337593543950.34m, 0.1m, 792281625142643375935439503.4m);
		    VerifyDivide<Exception>(7922816251426433759354395.034m, 0.1m, 79228162514264337593543950.34m);
		    VerifyDivide<Exception>(792281625142643375935439.5034m, 0.1m, 7922816251426433759354395.034m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 10m, 7922816251426433759354395033.5m);
		    VerifyDivide<Exception>(79228162514264337567774146561m, 10m, 7922816251426433756777414656.1m);
		    VerifyDivide<Exception>(79228162514264337567774146560m, 10m, 7922816251426433756777414656m);
		    VerifyDivide<Exception>(79228162514264337567774146559m, 10m, 7922816251426433756777414655.9m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.1m, 72025602285694852357767227577m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.01m, 78443725261647859003508861718m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.001m, 79149013500763574019524425909.091m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.0001m, 79220240490215316061937756559.344m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.00001m, 79227370240561931974224208092.919m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.000001m, 79228083286181051412492537842.462m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.0000001m, 79228154591448878448656105469.389m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.00000001m, 79228161721982720373716746597.833m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.000000001m, 79228162435036175158507775176.492m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.0000000001m, 79228162506341521342909798200.709m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.00000000001m, 79228162513472055968409229775.316m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.000000000001m, 79228162514185109431029765225.569m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.0000000000001m, 79228162514256414777292524693.522m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.00000000000001m, 79228162514263545311918807699.547m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.000000000000001m, 79228162514264258365381436070.742m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.0000000000000001m, 79228162514264329670727698908.567m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.00000000000000001m, 79228162514264336801262325192.357m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.000000000000000001m, 79228162514264337514315787820.736m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.0000000000000000001m, 79228162514264337585621134083.574m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.00000000000000000001m, 79228162514264337592751668709.857m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.000000000000000000001m, 79228162514264337593464722172.486m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.0000000000000000000001m, 79228162514264337593536027518.749m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.00000000000000000000001m, 79228162514264337593543158053.375m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.000000000000000000000001m, 79228162514264337593543871106.837m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.0000000000000000000000001m, 79228162514264337593543942412.184m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.00000000000000000000000001m, 79228162514264337593543949542.718m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.000000000000000000000000001m, 79228162514264337593543950255.772m);
		    VerifyDivide<Exception>(7922816251426433759354395033.5m, 0.9999999999999999999999999999m, 7922816251426433759354395034m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 10000000m, 7922816251426433759354.3950335m);
		    VerifyDivide<Exception>(7922816251426433759354395033.5m, 1.000001m, 7922808328618105141249253784.2m);
		    VerifyDivide<Exception>(7922816251426433759354395033.5m, 1.0000000000000000000000000001m, 7922816251426433759354395032.7m);
		    VerifyDivide<Exception>(7922816251426433759354395033.5m, 1.0000000000000000000000000002m, 7922816251426433759354395031.9m);
		    VerifyDivide<Exception>(7922816251426433759354395033.5m, 0.9999999999999999999999999999m, 7922816251426433759354395034m);
		    VerifyDivide<Exception>(79228162514264337593543950335m, 1.0000000000000000000000000001m, 79228162514264337593543950327m);
		    Decimal boundary7 = new Decimal((int)429u, (int)2133437386u, 0, false, 0);
		    Decimal boundary71 = new Decimal((int)429u, (int)2133437387u, 0, false, 0);
		    Decimal maxValueBy7 = Decimal.MaxValue * 0.0000001m;
		    VerifyDivide<Exception>(maxValueBy7, 1m, maxValueBy7);
		    VerifyDivide<Exception>(maxValueBy7, 1m, maxValueBy7);
		    VerifyDivide<Exception>(maxValueBy7, 0.0000001m, Decimal.MaxValue);
		    VerifyDivide<Exception>(boundary7, 1m, boundary7);
		    VerifyDivide<Exception>(boundary7, 0.000000100000000000000000001m, 91630438009337286849083695.62m);
		    VerifyDivide<Exception>(boundary71, 0.000000100000000000000000001m, 91630438052286959809083695.62m);
		    VerifyDivide<Exception>(7922816251426433759354.3950335m, 1m, 7922816251426433759354.3950335m);
		    VerifyDivide<Exception>(7922816251426433759354.3950335m, 0.0000001m, 79228162514264337593543950335m);
		
		    //[] DivideByZero exceptions
		    VerifyDivide<DivideByZeroException>(Decimal.One, Decimal.Zero);
		    VerifyDivide<DivideByZeroException>(Decimal.Zero, Decimal.Zero);
		    VerifyDivide<DivideByZeroException>(-5.00m, (-1m) * Decimal.Zero);
		    VerifyDivide<DivideByZeroException>(0.0m, -0.00m);
		
		    //[] Overflow exceptions
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, -0.9999999999999999999999999m);
		    VerifyDivide<OverflowException>(792281625142643.37593543950335m, 0.0000000000000079228162514264337593543950335m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.1m);
		    VerifyDivide<OverflowException>(7922816251426433759354395034m, 0.1m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.9m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.99m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.9999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.99999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.9999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.99999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.9999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.99999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.9999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.99999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.999999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.9999999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.99999999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.999999999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.9999999999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.99999999999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.999999999999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.9999999999999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.99999999999999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.999999999999999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.9999999999999999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.99999999999999999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.999999999999999999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, 0.9999999999999999999999999999m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, -0.1m);
		    VerifyDivide<OverflowException>(79228162514264337593543950335m, -0.9999999999999999999999999m);
		    VerifyDivide<OverflowException>(Decimal.MaxValue / 2, 0.5m);
		}
		
		[Test]
		public void TestFloor()
		{
		    // Decimal Decimal.Floor(Decimal)
		    Assert.AreEqual(123, Decimal.Floor((Decimal)123));
		    Assert.AreEqual(123, Decimal.Floor((Decimal)123.123));
		    Assert.AreEqual(-124, Decimal.Floor((Decimal)(-123.123)));
		    Assert.AreEqual(123, Decimal.Floor((Decimal)123.567));
		    Assert.AreEqual(-124, Decimal.Floor((Decimal)(-123.567)));
		}
		
		[Test]
		public void TestMaxValue()
		{
		    // Decimal Decimal.MaxValue
		    Assert.AreEqual(Decimal.MaxValue, 79228162514264337593543950335m);
		}
		
		[Test]
		public void TestMinusOne()
		{
		    // Decimal Decimal.MinusOne
		    Assert.AreEqual(Decimal.MinusOne, -1);
		}
		
		[Test]
		public void TestZero()
		{
		    // Decimal Decimal.Zero
		    Assert.AreEqual(Decimal.Zero, 0);
		}
		
		[Test]
		public void TestOne()
		{
		    // Decimal Decimal.One
		    Assert.AreEqual(Decimal.One, 1);
		}
		
		[Test]
		public void TestMinValue()
		{
		    // Decimal Decimal.MinValue
		    Assert.AreEqual(Decimal.MinValue, -79228162514264337593543950335m);
		}
		
		private void VerifyMultiply<T>(Decimal d1, Decimal d2, Decimal expected = Decimal.Zero) where T : Exception
		{
		    bool expectFailure = typeof(T) != typeof(Exception);
		
		    try
		    {
		        Decimal result1 = Decimal.Multiply(d1, d2);
		        Decimal result2 = d1 * d2;
		
		        Assert.IsFalse(expectFailure, "Expected an exception to be thrown");
		        Assert.AreEqual(result1, result2);
		        Assert.AreEqual(expected, result1);
		    }
		    catch (T)
		    {
		        Assert.IsTrue(expectFailure, "Didn't expect an exception to be thrown");
		    }
		}
		
		[Test]
		public void TestMultiply()
		{
		    // Decimal Decimal.Multiply(Decimal, Decimal)
		    // Decimal Decimal.op_Multiply(Decimal, Decimal)
		
		    VerifyMultiply<Exception>(Decimal.One, Decimal.One, Decimal.One);
		    VerifyMultiply<Exception>(7922816251426433759354395033.5m, new Decimal(10), Decimal.MaxValue);
		    VerifyMultiply<Exception>(0.2352523523423422342354395033m, 56033525474612414574574757495m, 13182018677937129120135020796m);
		    VerifyMultiply<Exception>(46161363632634613634.093453337m, 461613636.32634613634083453337m, 21308714924243214928823669051m);
		    VerifyMultiply<Exception>(0.0000000000000345435353453563m, .0000000000000023525235234234m, 0.0000000000000000000000000001m);
		
		    // Near MaxValue
		    VerifyMultiply<Exception>(79228162514264337593543950335m, 0.9m, 71305346262837903834189555302m);
		    VerifyMultiply<Exception>(79228162514264337593543950335m, 0.99m, 78435880889121694217608510832m);
		    VerifyMultiply<Exception>(79228162514264337593543950335m, 0.9999999999999999999999999999m, 79228162514264337593543950327m);
		    VerifyMultiply<Exception>(-79228162514264337593543950335m, 0.9m, -71305346262837903834189555302m);
		    VerifyMultiply<Exception>(-79228162514264337593543950335m, 0.99m, -78435880889121694217608510832m);
		    VerifyMultiply<Exception>(-79228162514264337593543950335m, 0.9999999999999999999999999999m, -79228162514264337593543950327m);
		
		    // Exceptions
		    VerifyMultiply<OverflowException>(Decimal.MaxValue, Decimal.MinValue);
		    VerifyMultiply<OverflowException>(Decimal.MinValue, 1.1m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.1m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.01m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.0001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.00001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.0000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.00000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.0000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.00000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.000000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.0000000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.00000000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.000000000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.0000000000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.00000000000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.000000000000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.0000000000000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.00000000000000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.000000000000000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.0000000000000000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.00000000000000000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.000000000000000000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.0000000000000000000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.00000000000000000000000001m);
		    VerifyMultiply<OverflowException>(79228162514264337593543950335m, 1.000000000000000000000000001m);
		    VerifyMultiply<OverflowException>(Decimal.MaxValue / 2, 2m);
		}
		
		[Test]
		public void TestNegate()
		{
		    // Decimal Decimal.Negate(Decimal)
		    Assert.AreEqual(0, Decimal.Negate(0));
		    Assert.AreEqual(1, Decimal.Negate(-1));
		    Assert.AreEqual(-1, Decimal.Negate(1));
		}
		
		[Test]
		public void Testop_Decrement()
		{
		    // Decimal Decimal.op_Decrement(Decimal)
		    Decimal d = 12345;
		    Assert.AreEqual(12344, --d);
		    d = 12345.678m;
		    Assert.AreEqual(12344.678m, --d);
		    d = -12345;
		    Assert.AreEqual(-12346, --d);
		    d = -12345.678m;
		    Assert.AreEqual(-12346.678m, --d);
		}
		
		[Test]
		public void Testop_Increment()
		{
		    // Decimal Decimal.op_Increment(Decimal)
		    Decimal d = 12345;
		    Assert.AreEqual(12346, ++d);
		    d = 12345.678m;
		    Assert.AreEqual(12346.678m, ++d);
		    d = -12345;
		    Assert.AreEqual(-12344m, ++d);
		    d = -12345.678m;
		    Assert.AreEqual(-12344.678m, ++d);
		}
		
		[Test]
		[SetCulture ("en")]
		public void TestParse()
		{
		    // Boolean Decimal.TryParse(String, NumberStyles, IFormatProvider, Decimal)
		    Assert.AreEqual(123, Decimal.Parse("123"));
		    Assert.AreEqual(-123, Decimal.Parse("-123"));
		    Assert.AreEqual(123.123m, Decimal.Parse("123.123"));
		    Assert.AreEqual(-123.123m, Decimal.Parse("-123.123"));
		
		    Decimal d;
		    Assert.IsTrue(Decimal.TryParse("79228162514264337593543950335", out d));
		    Assert.AreEqual(Decimal.MaxValue, d);
		
		    Assert.IsTrue(Decimal.TryParse("-79228162514264337593543950335", out d));
		    Assert.AreEqual(Decimal.MinValue, d);
		
		    Assert.IsTrue(Decimal.TryParse("79,228,162,514,264,337,593,543,950,335", NumberStyles.AllowThousands, NumberFormatInfo.CurrentInfo, out d));
		    Assert.AreEqual(Decimal.MaxValue, d);
		
		    Assert.IsFalse(Decimal.TryParse("ysaidufljasdf", out d));
		    Assert.IsFalse(Decimal.TryParse("79228162514264337593543950336", out d));
		}
		
		private void VerifyRemainder(Decimal d1, Decimal d2, Decimal expectedResult)
		{
		    Decimal result1 = Decimal.Remainder(d1, d2);
		    Decimal result2 = d1 % d2;
		
		    Assert.AreEqual(result1, result2);
		    Assert.AreEqual(expectedResult, result1);
		}
		
		[Test]
		public void TestRemainder()
		{
		    // Decimal Decimal.Remainder(Decimal, Decimal)
		    // Decimal Decimal.op_Modulus(Decimal, Decimal)
		    Decimal NegativeZero = new Decimal(0, 0, 0, true, 0);
		    VerifyRemainder(5m, 3m, 2m);
		    VerifyRemainder(5m, -3m, 2m);
		    VerifyRemainder(-5m, 3m, -2m);
		    VerifyRemainder(-5m, -3m, -2m);
		    VerifyRemainder(3m, 5m, 3m);
		    VerifyRemainder(3m, -5m, 3m);
		    VerifyRemainder(-3m, 5m, -3m);
		    VerifyRemainder(-3m, -5m, -3m);
		    VerifyRemainder(10m, -3m, 1m);
		    VerifyRemainder(-10m, 3m, -1m);
		    VerifyRemainder(-2.0m, 0.5m, -0.0m);
		    VerifyRemainder(2.3m, 0.531m, 0.176m);
		    VerifyRemainder(0.00123m, 3242m, 0.00123m);
		    VerifyRemainder(3242m, 0.00123m, 0.00044m);
		    VerifyRemainder(17.3m, 3m, 2.3m);
		    VerifyRemainder(8.55m, 2.25m, 1.80m);
		    VerifyRemainder(0.00m, 3m, 0.00m);
		    VerifyRemainder(NegativeZero, 2.2m, NegativeZero);
		
		    // [] Max/Min
		    VerifyRemainder(Decimal.MaxValue, Decimal.MaxValue, 0m);
		    VerifyRemainder(Decimal.MaxValue, Decimal.MinValue, 0m);
		    VerifyRemainder(Decimal.MaxValue, 1, 0m);
		    VerifyRemainder(Decimal.MaxValue, 2394713m, 1494647m);
		    VerifyRemainder(Decimal.MaxValue, -32768m, 32767m);
		    VerifyRemainder(-0.00m, Decimal.MaxValue, -0.00m);
		    VerifyRemainder(1.23984m, Decimal.MaxValue, 1.23984m);
		    VerifyRemainder(2398412.12983m, Decimal.MaxValue, 2398412.12983m);
		    VerifyRemainder(-0.12938m, Decimal.MaxValue, -0.12938m);
		
		    VerifyRemainder(Decimal.MinValue, Decimal.MinValue, NegativeZero);
		    VerifyRemainder(Decimal.MinValue, Decimal.MaxValue, NegativeZero);
		    VerifyRemainder(Decimal.MinValue, 1, NegativeZero);
		    VerifyRemainder(Decimal.MinValue, 2394713m, -1494647m);
		    VerifyRemainder(Decimal.MinValue, -32768m, -32767m); // ASURT #90921
		    VerifyRemainder(0.0m, Decimal.MinValue, 0.0m);
		    VerifyRemainder(1.23984m, Decimal.MinValue, 1.23984m);
		    VerifyRemainder(2398412.12983m, Decimal.MinValue, 2398412.12983m);
		    VerifyRemainder(-0.12938m, Decimal.MinValue, -0.12938m);
		
		    VerifyRemainder(57675350989891243676868034225m, 7m, 5m); // VSWhidbey #325142
		    VerifyRemainder(-57675350989891243676868034225m, 7m, -5m);
		    VerifyRemainder(57675350989891243676868034225m, -7m, 5m);
		    VerifyRemainder(-57675350989891243676868034225m, -7m, -5m);
		
		    // VSWhidbey #389382
		    VerifyRemainder(792281625142643375935439503.4m, 0.1m, 0.0m);
		    VerifyRemainder(79228162514264337593543950.34m, 0.1m, 0.04m);
		    VerifyRemainder(7922816251426433759354395.034m, 0.1m, 0.034m);
		    VerifyRemainder(792281625142643375935439.5034m, 0.1m, 0.0034m);
		    VerifyRemainder(79228162514264337593543950335m, 10m, 5m);
		    VerifyRemainder(79228162514264337567774146561m, 10m, 1m);
		    VerifyRemainder(79228162514264337567774146560m, 10m, 0m);
		    VerifyRemainder(79228162514264337567774146559m, 10m, 9m);
		}
		
		private void VerifySubtract<T>(Decimal d1, Decimal d2, Decimal expected = Decimal.Zero) where T : Exception
		{
		    bool expectFailure = typeof(T) != typeof(Exception);
		
		    try
		    {
		        Decimal result1 = Decimal.Subtract(d1, d2);
		        Decimal result2 = d1 - d2;
		
		        Assert.IsFalse(expectFailure, "Expected an exception to be thrown");
		        Assert.AreEqual(result1, result2);
		        Assert.AreEqual(expected, result1);
		    }
		    catch (T)
		    {
		        Assert.IsTrue(expectFailure, "Didn't expect an exception to be thrown");
		    }
		}
		
		[Test]
		public void TestSubtract()
		{
		    // Decimal Decimal.Subtract(Decimal, Decimal)
		    // Decimal Decimal.op_Subtraction(Decimal, Decimal)
		
		    VerifySubtract<Exception>(1, 1, 0);
		    VerifySubtract<Exception>(-1, 1, -2);
		    VerifySubtract<Exception>(1, -1, 2);
		    VerifySubtract<Exception>(Decimal.MaxValue, Decimal.Zero, Decimal.MaxValue);
		    VerifySubtract<Exception>(Decimal.MinValue, Decimal.Zero, Decimal.MinValue);
		    VerifySubtract<Exception>(79228162514264337593543950330m, -5, Decimal.MaxValue);
		    VerifySubtract<Exception>(79228162514264337593543950330m, 5, 79228162514264337593543950325m);
		    VerifySubtract<Exception>(-79228162514264337593543950330m, 5, Decimal.MinValue);
		    VerifySubtract<Exception>(-79228162514264337593543950330m, -5, -79228162514264337593543950325m);
		    VerifySubtract<Exception>(1234.5678m, 0.00009m, 1234.56771m);
		    VerifySubtract<Exception>(-1234.5678m, 0.00009m, -1234.56789m);
		    VerifySubtract<Exception>(0.1111111111111111111111111111m, 0.1111111111111111111111111111m, 0);
		    VerifySubtract<Exception>(0.2222222222222222222222222222m,
		                         0.1111111111111111111111111111m,
		                         0.1111111111111111111111111111m);
		    VerifySubtract<Exception>(1.1111111111111111111111111110m,
		                         0.5555555555555555555555555555m,
		                         0.5555555555555555555555555555m);
		}
		
		[Test]
		public void TestTruncate()
		{
		    // Decimal Decimal.Truncate(Decimal)
		    Assert.AreEqual(123, Decimal.Truncate((Decimal)123));
		    Assert.AreEqual(123, Decimal.Truncate((Decimal)123.123));
		    Assert.AreEqual(-123, Decimal.Truncate((Decimal)(-123.123)));
		    Assert.AreEqual(123, Decimal.Truncate((Decimal)123.567));
		    Assert.AreEqual(-123, Decimal.Truncate((Decimal)(-123.567)));
		}
		
		[Test]
		public void TestRound()
		{
		    // Decimal Decimal.Truncate(Decimal)
		    // Assert.AreEqual<Decimal>(123, Decimal.Round((Decimal)123, 2));
		    // Assert.AreEqual<Decimal>((Decimal)123.123, Decimal.Round((Decimal)123.123, 3));
		    // Assert.AreEqual<Decimal>((Decimal)(-123.1), Decimal.Round((Decimal)(-123.123), 1));
		    // Assert.AreEqual<Decimal>(124, Decimal.Round((Decimal)123.567, 0));
		    // Assert.AreEqual<Decimal>((Decimal)(-123.567), Decimal.Round((Decimal)(-123.567), 4));
		}
		
		[Test]
		public void TestCompare()
		{
		    // Int32 Decimal.Compare(Decimal, Decimal)
		    Assert.IsTrue(Decimal.Compare(Decimal.Zero, Decimal.Zero) == 0);
		    Assert.IsTrue(Decimal.Compare(Decimal.Zero, Decimal.One) < 0);
		    Assert.IsTrue(Decimal.Compare(Decimal.One, Decimal.Zero) > 0);
		    Assert.IsTrue(Decimal.Compare(Decimal.MinusOne, Decimal.Zero) < 0);
		    Assert.IsTrue(Decimal.Compare(Decimal.Zero, Decimal.MinusOne) > 0);
		    Assert.IsTrue(Decimal.Compare(5, 3) > 0);
		    Assert.IsTrue(Decimal.Compare(5, 5) == 0);
		    Assert.IsTrue(Decimal.Compare(5, 9) < 0);
		    Assert.IsTrue(Decimal.Compare(-123.123m, 123.123m) < 0);
		    Assert.IsTrue(Decimal.Compare(Decimal.MaxValue, Decimal.MaxValue) == 0);
		    Assert.IsTrue(Decimal.Compare(Decimal.MinValue, Decimal.MinValue) == 0);
		    Assert.IsTrue(Decimal.Compare(Decimal.MinValue, Decimal.MaxValue) < 0);
		    Assert.IsTrue(Decimal.Compare(Decimal.MaxValue, Decimal.MinValue) > 0);
		}
		
		[Test]
		public void TestCompareTo()
		{
		    // Int32 Decimal.CompareTo(Decimal)
		    Decimal d = 456;
		    Assert.IsTrue(d.CompareTo(456m) == 0);
		    Assert.IsTrue(d.CompareTo(457m) < 0);
		    Assert.IsTrue(d.CompareTo(455m) > 0);
		}
		
		[Test]
		public void TestSystemIComparableCompareTo()
		{
		    // Int32 Decimal.System.IComparable.CompareTo(Object)
		    IComparable d = (Decimal)248;
		    Assert.IsTrue(d.CompareTo(248m) == 0);
		    Assert.IsTrue(d.CompareTo(249m) < 0);
		    Assert.IsTrue(d.CompareTo(247m) > 0);
		    Assert.IsTrue(d.CompareTo(null) > 0);
		
		    AssertExtensions.Throws<ArgumentException>(() => d.CompareTo("248"), "Expected an argument exception");
		}
		
		[Test]
		public void TestGetHashCode()
		{
		    // Int32 Decimal.GetHashCode()
		    Assert.AreNotEqual(Decimal.MinusOne.GetHashCode(), Decimal.One.GetHashCode());
		}
		
		[Test]
		public void TestToSingle()
		{
		    // Single Decimal.ToSingle(Decimal)
		    Single s = 12345.12f;
		    Assert.AreEqual(s, Decimal.ToSingle((Decimal)s));
		    Assert.AreEqual(-s, Decimal.ToSingle((Decimal)(-s)));
		
		    s = 1e20f;
		    Assert.AreEqual(s, Decimal.ToSingle((Decimal)s));
		    Assert.AreEqual(-s, Decimal.ToSingle((Decimal)(-s)));
		
		    s = 1e27f;
		    Assert.AreEqual(s, Decimal.ToSingle((Decimal)s));
		    Assert.AreEqual(-s, Decimal.ToSingle((Decimal)(-s)));
		}
		
		[Test]
		public void TestToDouble()
		{
		    Double d = Decimal.ToDouble(new Decimal(0, 0, 1, false, 0));
		
		    // Double Decimal.ToDouble(Decimal)
		    Double dbl = 123456789.123456;
		    Assert.AreEqual(dbl, Decimal.ToDouble((Decimal)dbl));
		    Assert.AreEqual(-dbl, Decimal.ToDouble((Decimal)(-dbl)));
		
		    dbl = 1e20;
		    Assert.AreEqual(dbl, Decimal.ToDouble((Decimal)dbl));
		    Assert.AreEqual(-dbl, Decimal.ToDouble((Decimal)(-dbl)));
		
		    dbl = 1e27;
		    Assert.AreEqual(dbl, Decimal.ToDouble((Decimal)dbl));
		    Assert.AreEqual(-dbl, Decimal.ToDouble((Decimal)(-dbl)));
		
		    dbl = Int64.MaxValue;
		    // Need to pass in the Int64.MaxValue to ToDouble and not dbl because the conversion to double is a little lossy and we want precision
		    Assert.AreEqual(dbl, Decimal.ToDouble((Decimal)Int64.MaxValue));
		    Assert.AreEqual(-dbl, Decimal.ToDouble((Decimal)(-Int64.MaxValue)));
		}
		
		[Test]
		public void TestToInt16()
		{
		    // Int16 Decimal.ToInt16(Decimal)
		    Assert.AreEqual(Int16.MaxValue, Decimal.ToInt16((Decimal)Int16.MaxValue));
		    Assert.AreEqual(Int16.MinValue, Decimal.ToInt16((Decimal)Int16.MinValue));
		}
		
		[Test]
		public void TestToInt32()
		{
		    // Int32 Decimal.ToInt32(Decimal)
		    Assert.AreEqual(Int32.MaxValue, Decimal.ToInt32((Decimal)Int32.MaxValue));
		    Assert.AreEqual(Int32.MinValue, Decimal.ToInt32((Decimal)Int32.MinValue));
		}
		
		[Test]
		public void TestGetBits()
		{
		    // Int32[] Decimal.GetBits(Decimal)
		}
		
		[Test]
		public void TestToInt64()
		{
		    // Int64 Decimal.ToInt64(Decimal)
		    Assert.AreEqual(Int64.MaxValue, Decimal.ToInt64((Decimal)Int64.MaxValue));
		    Assert.AreEqual(Int64.MinValue, Decimal.ToInt64((Decimal)Int64.MinValue));
		}
		
		[Test]
		public void TestToSByte()
		{
		    // SByte Decimal.ToSByte(Decimal)
		    Assert.AreEqual(SByte.MaxValue, Decimal.ToSByte((Decimal)SByte.MaxValue));
		    Assert.AreEqual(SByte.MinValue, Decimal.ToSByte((Decimal)SByte.MinValue));
		}
		
		[Test]
		public void TestToUInt16()
		{
		    // UInt16 Decimal.ToUInt16(Decimal)
		    Assert.AreEqual(UInt16.MaxValue, Decimal.ToUInt16((Decimal)UInt16.MaxValue));
		    Assert.AreEqual(UInt16.MinValue, Decimal.ToUInt16((Decimal)UInt16.MinValue));
		}
		
		[Test]
		public void TestToUInt32()
		{
		    // UInt32 Decimal.ToUInt32(Decimal)
		    Assert.AreEqual(UInt32.MaxValue, Decimal.ToUInt32((Decimal)UInt32.MaxValue));
		    Assert.AreEqual(UInt32.MinValue, Decimal.ToUInt32((Decimal)UInt32.MinValue));
		}
		
		[Test]
		public void TestToUInt64()
		{
		    // UInt64 Decimal.ToUInt64(Decimal)
		    Assert.AreEqual(UInt64.MaxValue, Decimal.ToUInt64((Decimal)UInt64.MaxValue));
		    Assert.AreEqual(UInt64.MinValue, Decimal.ToUInt64((Decimal)UInt64.MinValue));
		}
		
		[Test]
		[SetCulture ("en")]
		public void TestToString()
		{
		    // String Decimal.ToString()
		    Decimal d1 = 6310.23m;
		    Assert.AreEqual("6310.23", d1.ToString());
		
		    Decimal d2 = -8249.000003m;
		    Assert.AreEqual("-8249.000003", d2.ToString());
		
		    Assert.AreEqual("79228162514264337593543950335", Decimal.MaxValue.ToString());
		    Assert.AreEqual("-79228162514264337593543950335", Decimal.MinValue.ToString());
		}
		
		[Test]
		public void Testctor()
		{
		    Decimal d;
		    // Void Decimal..ctor(Double)
		    d = new Decimal((Double)123456789.123456);
		    Assert.AreEqual(d, (Decimal)123456789.123456);
		
		    // Void Decimal..ctor(Int32)
		    d = new Decimal((Int32)Int32.MaxValue);
		    Assert.AreEqual(d, Int32.MaxValue);
		
		    // Void Decimal..ctor(Int64)
		    d = new Decimal((Int64)Int64.MaxValue);
		    Assert.AreEqual(d, Int64.MaxValue);
		
		    // Void Decimal..ctor(Single)
		    d = new Decimal((Single)123.123);
		    Assert.AreEqual(d, (Decimal)123.123);
		
		    // Void Decimal..ctor(UInt32)
		    d = new Decimal((UInt32)UInt32.MaxValue);
		    Assert.AreEqual(d, UInt32.MaxValue);
		
		    // Void Decimal..ctor(UInt64)
		    d = new Decimal((UInt64)UInt64.MaxValue);
		    Assert.AreEqual(d, UInt64.MaxValue);
		
		    // Void Decimal..ctor(Int32, Int32, Int32, Boolean, Byte)
		    d = new Decimal(1, 1, 1, false, 0);
		    Decimal d2 = 3;
		    d2 += UInt32.MaxValue;
		    d2 += UInt64.MaxValue;
		    Assert.AreEqual(d, d2);
		
		    // Void Decimal..ctor(Int32[])
		    d = new Decimal(new Int32[] { 1, 1, 1, 0 });
		    Assert.AreEqual(d, d2);
		}
		
		[Test]
		[SetCulture ("en")]
		public void TestNumberBufferLimit()
		{
		    Decimal dE = 1234567890123456789012345.6785m;
		    string s1 = "1234567890123456789012345.678456";
		    Decimal d1 = Decimal.Parse(s1);
		    Assert.AreEqual(d1, dE);
		    return;
		}
	}
}
