// Copyright 2004-2006 Castle Project - http://www.castleproject.org/
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

namespace Castle.DynamicProxy.Tests
{
	using Castle.DynamicProxy.Test.Classes;
	using Castle.DynamicProxy.Test.Interceptors;
	using NUnit.Framework;

	[TestFixture]
	public class BasicClassProxyTestCase
	{
		private ProxyGenerator _generator;

		[SetUp]
		public void Init()
		{
			_generator = new ProxyGenerator();
		}

		[Test]
		public void ProxyForClass()
		{
			object proxy = _generator.CreateClassProxy(
				typeof(ServiceClass), new ResultModifiedInvocationHandler());

			Assert.IsNotNull(proxy);
			Assert.IsTrue(typeof(ServiceClass).IsAssignableFrom(proxy.GetType()));

			ServiceClass inter = (ServiceClass) proxy;

			Assert.AreEqual(44, inter.Sum(20, 25));
			Assert.AreEqual(true, inter.Valid);
		}
	}
}