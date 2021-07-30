# Value Object (DDD) with with Entity Framework Core
The goal of this project is to show a sample Value Object (DDD) in conjunction with Entity Framework Core to novices.


### What is a Value Object

A Value Object is an immutable type that can only be differentiated by the state of its properties. That is, unlike an Entity, which has a unique identifier and maintains its uniqueness even when its properties are identical, two Value Objects with identical properties can be considered equal. Value Objects are a design pattern introduced by Evans in his book Domain-Driven Design.

For example:

```
public class UserName
{
     public SomeValue(string name)
     {
         Name = name;
     }

  public string Name { get; private set; }
}
  
public void Validate(string value)
{
    if (string.IsNullOrWhiteSpace(value: value))
    {
         throw new InvalidUserNameException(userName: value);
    }

    if (value.Length < 3)
    {
         throw new InvalidUserNameException(userName: value);
    }
}
```

###  Value objects are not value types

Avoid conflating value objects and value types. The former is a pattern derived from DDD that is typically implemented using classes (making them reference types). While the distinction between value types and reference types is significant for the underlying platform, it is a lower level concern than the value object pattern used in Domain-Driven Design.
