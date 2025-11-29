using System;
using System.Text.RegularExpressions;
namespace App.Domain.Core.AuthorAgg.ValueObject;

public class Email : IEquatable<Email>
{
    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new Exception("Email cannot be empty.");

        
        var pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        if (!Regex.IsMatch(email, pattern))
            throw new ArgumentException("Invalid email format.");

        return new Email(email);
    }

    public override string ToString() => Value;

   
    public override bool Equals(object obj) => Equals(obj as Email);

    public bool Equals(Email other) => other != null && Value == other.Value;

    public override int GetHashCode() => Value.GetHashCode();
}

