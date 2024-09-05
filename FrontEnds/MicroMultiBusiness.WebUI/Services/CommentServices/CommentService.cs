using MicroMultiBusiness.DTOLayer.CommentDTOs;
using Newtonsoft.Json;

namespace MicroMultiBusiness.WebUI.Services.CommentServices
{
    public class CommentService : ICommentService
    {
        private readonly HttpClient _httpClient;

        public CommentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<ResultCommentDTO>> CommentListByProductId(string id)
        {
            var responseMessage = await _httpClient.GetAsync($"comments/CommentListByProductId/{id}");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCommentDTO>>(jsonData);
            return values;
        }

        public async Task CreateCommentAsync(CreateCommentDTO createCommentDTO)
        {
            await _httpClient.PostAsJsonAsync<CreateCommentDTO>("comments", createCommentDTO);
        }

        public async Task DeleteCommentAsync(string id)
        {
            await _httpClient.DeleteAsync("comments?id=" + id);
        }

        public async Task<List<ResultCommentDTO>> GetAllCommentsAsync()
        {
            var response = await _httpClient.GetAsync("comments");
            var valueList = await response.Content.ReadFromJsonAsync<List<ResultCommentDTO>>();
            return valueList;
        }

        public async Task<UpdateCommentDTO> GetByIdCommentAsync(string id)
        {
            var response = await _httpClient.GetAsync("comments/" + id);
            var value = await response.Content.ReadFromJsonAsync<UpdateCommentDTO>();
            return value;
        }

        public async Task UpdateCommentAsync(UpdateCommentDTO updateCommentDTO)
        {
            await _httpClient.PutAsJsonAsync<UpdateCommentDTO>("comments", updateCommentDTO);
        }
    }
}
