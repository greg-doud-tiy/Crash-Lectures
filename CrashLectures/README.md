# Crash Lectures
Crash lectures are short lectures about a single topic. They are usually done when one or more students ask a similar question about some topic and the choice is made to just communicate the information about the topic to all the students.

The crash lecture topics covered so far are:

- Implementing Custom Collections
Implementing Custom Collections

When you are creating an application and you need a collection to instances of classes
you'll typically have to decide between using a List<> or a Dictionary<,>. Which one
should you choose?

If the collection is only going to be used in a few isolated places in your application, 
you can just use either collection directly, but if the collection instance will be used
in many areas of your application, I recommend that you create your own custom collection
class as it will likely save you some significant time and headaches. Here's why.

Suppose you create the List<> collection directly. As other areas of your application use
the collection and retrieve data and possibly add new data to it, they'll be required to 
use the syntax of the List<> to add <code>instance.Add(object)</code> and retrieve <code>instance[0]</code>. This
syntax will be spread throughout the application.

Now suppose that you decide that the Dictionary<,> is a better choice. You can easily change
where the collection instance is defined, but you'll need to find all the places where
retrieval or maintenance is done and change those lines of code the use the Dictonary<,> 
equivalent like <code>instance.Add(key, object)</code> and <code>instance[key]</code>.

If, on the other hand, you implement a custom collection class that inherits the inital
collection class you'll use and pass it around, you can adapt to a change in collection
class selection by simply modifying the custom collection class to provide the methods
the are implemented everywhere in the application. Here is an example:

This code implements a custom collection class for the Widget class. In the WidgetCollection
class, the commented code is all that is needed to have the WidgetCollection class implement
a List<Widget> collection. When the choice is made to change to a Dictionary<int, Widget>,
it is changed to its existing state. The one method was created so that any place that an
Add() was done while it was a List<> will still work when converted to a Dictionary.

Pretty cool huh!

- the Try..Catch block