using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class MovieClientAdminService(HttpClient httpClient) : IMovieAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<MovieAdminDto?> AddAsync(MovieAdminDto movieAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/movieAdmin", movieAdminDto);

        return await result.Content.ReadFromJsonAsync<MovieAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/movieAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<MovieAdminDto?> EditAsync(MovieAdminDto movieAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/movieAdmin/{movieAdminDto.Id}", movieAdminDto);

        return await result.Content.ReadFromJsonAsync<MovieAdminDto>();
    }

    public async Task<List<Movie>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<Movie>>($"/api/admin/movieAdmin?userName={userName}");

        return result;
    }

    public async Task<MovieAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<MovieAdminDto>($"/api/admin/movieAdmin/{id}?userName={userName}");

        return result;
    }
}
