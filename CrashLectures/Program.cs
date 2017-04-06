using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrashLectures {
	class Program {

		class nameType {
			public string first;
			public string last;
		}

		void ConcatenateStringsUsingLinq() {
			List<nameType> ns = new List<nameType>() {
				new nameType() { first = "Greg", last = "Doud" },
				new nameType() { first = "cindy",  last = "doud" },
				new nameType() { first = "nick",  last = "doud" },
				new nameType() { first = "ken",  last = "doud" }
			};
			var greg = from n in ns
					   where n.first == "Greg"
					   select new { full = n.first + " " + n.last };
			
		}
		/// <summary>
		/// Whenever any operation is capable of throwing an Exception, it is good programming 
		/// practice to handle the exception gracefully even if there is nothing that can be done 
		/// other than terminate the program. In the worse case, the exception message could be 
		/// put on an error page, displayed to the user, and a message could tell the user to 
		/// contact their system administrator.
		/// 
		/// All exception objects end with "Exception" and are ultimately derived from
		/// System.Exception. Therefore, they'll include a text "Message" property which should
		/// describe the exception. It will also have an "InnerException" that may point to
		/// another Exception so exceptions can be 'chained' together.
		/// 
		/// It is possible to create your own, custom exceptions. Just create a new class and 
		/// derive from Exception. It is typical to have constructors with zero parms, a single
		/// string for a message, and two parameters of string and Exception.
		/// 
		/// To throw your own exception, 
		/// <code>throw new YourCustomException({{string message}, Exception innerException})</code>
		/// </summary>
		void UsingTriCatchBlocks() {
			// force a zero divide error
			int x = 1, y = 0;
			//var result1 = x / y; // this would throw an exception
			// to catch the exception
			try {
				var result2 = x / y;
			} catch(DivideByZeroException ex) {
				// this code run after the exception occurs
				System.Diagnostics.Debug.WriteLine("The exception occurred here.");
			} catch(Exception ex) {
				// more specific exceptions should be caught first
				// this catches any exception other than the others caught
				System.Diagnostics.Debug.WriteLine(ex.Message);
			} finally {
				// this block always executes
			}
			// program continues gracefully
			System.Diagnostics.Debug.WriteLine("Done...");
		}
		/// <summary>
		/// Implementing Custom Collections
		/// 
		/// When you are creating an application and you need a collection to instances of classes
		/// you'll typically have to decide between using a List<> or a Dictionary<,>. Which one
		/// should you choose?
		/// 
		/// If the collection is only going to be used in a few isolated places in your application, 
		/// you can just use either collection directly, but if the collection instance will be used
		/// in many areas of your application, I recommend that you create your own custom collection
		/// class as it will likely save you some significant time and headaches. Here's why.
		/// 
		/// Suppose you create the List<> collection directly. As other areas of your application use
		/// the collection and retrieve data and possibly add new data to it, they'll be required to 
		/// use the syntax of the List<> to add <code>instance.Add(object)</code> and retrieve <code>instance[0]</code>. This
		/// syntax will be spread throughout the application.
		/// 
		/// Now suppose that you decide that the Dictionary<,> is a better choice. You can easily change
		/// where the collection instance is defined, but you'll need to find all the places where
		/// retrieval or maintenance is done and change those lines of code the use the Dictonary<,> 
		/// equivalent like <code>instance.Add(key, object)</code> and <code>instance[key]</code>.
		/// 
		/// If, on the other hand, you implement a custom collection class that inherits the inital
		/// collection class you'll use and pass it around, you can adapt to a change in collection
		/// class selection by simply modifying the custom collection class to provide the methods
		/// the are implemented everywhere in the application. Here is an example:
		/// 
		/// This code implements a custom collection class for the Widget class. In the WidgetCollection
		/// class, the commented code is all that is needed to have the WidgetCollection class implement
		/// a List<Widget> collection. When the choice is made to change to a Dictionary<int, Widget>,
		/// it is changed to its existing state. The one method was created so that any place that an
		/// Add() was done while it was a List<> will still work when converted to a Dictionary.
		/// 
		/// Pretty cool huh!
		/// </summary>
		void ImplementingCustomCollections() {
			// create instances of Widgets
			var w1 = new Widget() { Id = 1, Name = "Widget1" };
			var w2 = new Widget() { Id = 2, Name = "Widget2" };
			var w3 = new Widget() { Id = 3, Name = "Widget3" };
			// load a List with Widget instances
			List<Widget> widgetList = new List<Widget>();
			widgetList.Add(w1);
			widgetList.Add(w2);
			widgetList.Add(w3);
			// load a Dictionary with Widget instances
			Dictionary<int, Widget> widgetDictionary = new Dictionary<int, Widget>();
			widgetDictionary.Add(w1.Id, w1);
			widgetDictionary.Add(w2.Id, w1);
			widgetDictionary.Add(w3.Id, w1);
			// load the custom WidgetCollection with instances of Widget
			// this works whether the custom class derives from List<> or Dictionary<>
			WidgetCollection widgetCollection = new WidgetCollection();
			widgetCollection.Add(w1);
			widgetCollection.Add(w2);
			widgetCollection.Add(w3);
		}
		static void Main(string[] args) {
			Program pgm = new Program();
			//pgm.ImplementingCustomCollections();
			//pgm.UsingTriCatchBlocks();
			pgm.ConcatenateStringsUsingLinq();
		}
	}
}
