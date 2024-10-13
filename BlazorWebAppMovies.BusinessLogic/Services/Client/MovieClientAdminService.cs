using System.Net.Http.Json;
using ApplicationNamePlaceholder.BusinessLogic.Entities;
using ApplicationNamePlaceholder.BusinessLogic.Entities.Dtos;

namespace ApplicationNamePlaceholder.BusinessLogic.Services.Client;

public class EntityNamePlaceholderClientAdminService(HttpClient httpClient) : IEntityNamePlaceholderAdminService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<EntityNamePlaceholderAdminDto?> AddAsync(EntityNamePlaceholderAdminDto EntityLowercaseNamePlaceholderAdminDto)
    {
        var result = await _httpClient.PostAsJsonAsync("/api/admin/EntityLowercaseNamePlaceholderAdmin", EntityLowercaseNamePlaceholderAdminDto);

        return await result.Content.ReadFromJsonAsync<EntityNamePlaceholderAdminDto>();
    }

    public async Task<bool> DeleteAsync(string userName, Guid id)
    {
        var result = await _httpClient.DeleteAsync($"/api/admin/EntityLowercaseNamePlaceholderAdmin/{id}?userName={userName}");

        return await result.Content.ReadFromJsonAsync<bool>();
    }

    public async Task<EntityNamePlaceholderAdminDto?> EditAsync(EntityNamePlaceholderAdminDto EntityLowercaseNamePlaceholderAdminDto)
    {
        var result = await _httpClient.PutAsJsonAsync($"/api/admin/EntityLowercaseNamePlaceholderAdmin/{EntityLowercaseNamePlaceholderAdminDto.Id}", EntityLowercaseNamePlaceholderAdminDto);

        return await result.Content.ReadFromJsonAsync<EntityNamePlaceholderAdminDto>();
    }

    public async Task<List<EntityNamePlaceholder>?> GetAllAsync(string userName)
    {
        var result = await _httpClient.GetFromJsonAsync<List<EntityNamePlaceholder>>($"/api/admin/EntityLowercaseNamePlaceholderAdmin?userName={userName}");

        return result;
    }

    public async Task<EntityNamePlaceholderAdminDto?> GetByIdAsync(string userName, Guid id)
    {
        var result = await _httpClient.GetFromJsonAsync<EntityNamePlaceholderAdminDto>($"/api/admin/EntityLowercaseNamePlaceholderAdmin/{id}?userName={userName}");

        return result;
    }
}
