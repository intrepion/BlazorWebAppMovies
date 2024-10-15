using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Repositories.Client;

public class EntityNamePlaceholderClientAdminRepository(HttpClient httpClient) : IEntityNamePlaceholderAdminRepository
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<EntityNamePlaceholderAdminDto?> AddAsync(EntityNamePlaceholderAdminDto castMemberAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/castMemberAdmin", castMemberAdminDto);

        return await result.Content.ReadFromJsonAsync<EntityNamePlaceholderAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/castMemberAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<EntityNamePlaceholderAdminDto?> EditAsync(EntityNamePlaceholderAdminDto castMemberAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/castMemberAdmin/{castMemberAdminDto.Id}", castMemberAdminDto);

        return await result.Content.ReadFromJsonAsync<EntityNamePlaceholderAdminDto>();
    }

    public async Task<List<EntityNamePlaceholder>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<EntityNamePlaceholder>>($"/api/admin/castMemberAdmin?userName={userName}");

        return result;
    }

    public async Task<EntityNamePlaceholderAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<EntityNamePlaceholderAdminDto>($"/api/admin/castMemberAdmin/{id}?userName={userName}");

        return result;
    }
}
