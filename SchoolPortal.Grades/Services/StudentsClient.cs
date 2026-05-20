using System.Net;

namespace SchoolPortal.Grades.Services;

public class StudentsClient
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<StudentsClient> _logger;

    public StudentsClient(HttpClient httpClient, ILogger<StudentsClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<bool> IsStudentExistsAsync(int studentId)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/students/check/{studentId}");

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return true;
            }

            return false;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error while calling Students Service for ID: {StudentId}", studentId);

            return false;
        }
    }
}