/*
 * Created by SharpDevelop.
 * User: jcoffman
 * Date: 4/28/2009
 * Time: 4:03 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace BooBaseDSLToys
{	
	using System.Reflection;
	using Rhino.DSL;
	
	class Program
	{
		static void Main()
		{
			//add the DSL factory
			var factory = new DslFactory();
			
			//register type
			//factory.Register<BaseOrderActionsDSL>(new OrderActionsDslEngine());
			
			//load dsl script
			//BaseOrderActionsDSL instance = factory.Create<BaseOrderActionsDSL>(@"Orders/OrderBusinessRules.boo");
			
			//use DSL target object
//			instance.Order = new Order();
//			instance.Order.TotalCost = 5000;
//			instance.User = new User();
//			instance.User.IsPreferred = true;
			
			//prepare DSL IL
			//instance.Prepare();
			
			//run DSL logic
			//instance.Execute();
			
			Console.WriteLine();
			Console.WriteLine("Just checking..");
			Console.ReadLine();
		}
	}
}
