﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Rally.RestApi.Test
{
	[TestClass]
	public class QueryTest
	{
		[TestMethod]
		public void TestNullValue()
		{
			var q = new Query("Actuals ", Query.Operator.Equals, null);
			Assert.AreEqual("(Actuals  = null)", q.QueryClause);
		}

		[TestMethod]
		public void TestAnd()
		{
			Query q = new Query("Release.Name", Query.Operator.Equals, "My Release");
			Assert.AreEqual(q.QueryClause, "(Release.Name = \"My Release\")");

			Query q2 = q.And(new Query("Iteration.Name", Query.Operator.Equals, "My Iteration"));
			Assert.AreEqual(q2.QueryClause, "((Release.Name = \"My Release\") AND (Iteration.Name = \"My Iteration\"))");
		}

		[TestMethod]
		public void TestOr()
		{
			var q = new Query("Release.Name", Query.Operator.Equals, "My Release");
			Assert.AreEqual(q.QueryClause, "(Release.Name = \"My Release\")");

			Query q2 = q.Or(new Query("Iteration.Name", Query.Operator.Equals, "My Iteration"));
			Assert.AreEqual(q2.QueryClause, "((Release.Name = \"My Release\") OR (Iteration.Name = \"My Iteration\"))");
		}

		[TestMethod]
		public void TestStaticAnd()
		{
			Assert.AreEqual(Query.And(new Query("Release.Name", Query.Operator.Equals, "My Release"),
																new Query("Iteration.Name", Query.Operator.Equals, "My Iteration")).QueryClause,
											"((Release.Name = \"My Release\") AND (Iteration.Name = \"My Iteration\"))");
		}

		[TestMethod]
		public void TestStaticOr()
		{
			Assert.AreEqual(Query.Or(new Query("Release.Name", Query.Operator.Equals, "My Release"),
															 new Query("Iteration.Name", Query.Operator.Equals, "My Iteration")).QueryClause,
											"((Release.Name = \"My Release\") OR (Iteration.Name = \"My Iteration\"))");
		}

		[TestMethod]
		public void TestOperators()
		{
			foreach (Query.Operator op in Enum.GetValues(typeof(Query.Operator)))
			{
				var q = new Query("Release.Name", op, "My Release");
				Assert.AreEqual(q.QueryClause, "(Release.Name " + Query.GetOperator(op) + " \"My Release\")");
			}
		}

		[TestMethod]
		public void TestGetValue()
		{
			var query = new Query("Name", Query.Operator.Equals, "value");
			Assert.AreEqual(query.Value, "value");
		}


		[TestMethod]
		public void TestStaticGetOperator()
		{

			Assert.AreEqual(Query.GetOperator("="), Query.Operator.Equals);
		}

		[TestMethod]
		public void TestStaticParse()
		{
			Query query = Query.Parse("(Name = Value)");
			Assert.AreEqual(query.QueryOperator, Query.Operator.Equals);
			Assert.AreEqual(query.Value, "Value");
			Assert.AreEqual(query.Attribute, "Name");
		}

		[TestMethod]
		public void TestTryParseQueryOperator()
		{
			Enum.GetValues(typeof(Query.Operator));
			Array values = Enum.GetValues(typeof(Query.Operator));
			foreach (Query.Operator queryOperator in values)
				HelperParseQueryOperator(queryOperator);
		}

		public void HelperParseQueryOperator(Query.Operator queryOperator)
		{
			string operatorValue = Query.GetOperator(queryOperator);

			Query.Operator foundQueryOperator;
			Assert.IsTrue(Query.TryParseQueryOperator(operatorValue, out foundQueryOperator));
			Assert.AreEqual(queryOperator, foundQueryOperator);
		}
	}
}