using TriviaApi.DataAccess.Models;

namespace TriviaApi.DataAccess;

public class QuestionEqualityComparer : IEqualityComparer<QuestionModel>
{
    public bool Equals(QuestionModel x, QuestionModel y)
    {
        if (ReferenceEquals(x, y)) return true;
        if (ReferenceEquals(x, null)) return false;
        if (ReferenceEquals(y, null)) return false;
        if (x.GetType() != y.GetType()) return false;
        return x.Statement == y.Statement;
    }

    public int GetHashCode(QuestionModel obj)
    {
        return obj.Statement.GetHashCode();
    }
}