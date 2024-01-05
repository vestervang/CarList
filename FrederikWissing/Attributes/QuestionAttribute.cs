namespace CarList.Attributes;

public class QuestionAttribute(string question) : Attribute
{
    public string Question { get; } = question;
}