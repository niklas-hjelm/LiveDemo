using System.Text.Json.Serialization;

namespace TriviaApi.DTOs;

public class QuizResponse
{
    [JsonPropertyName("response_code")]
    public int ResponseCode { get; set; }
    public IEnumerable<QuestionDTO> Results { get; set; }
    //TODO: 2
}