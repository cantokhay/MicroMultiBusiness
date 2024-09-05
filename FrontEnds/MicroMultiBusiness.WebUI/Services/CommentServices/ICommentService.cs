using MicroMultiBusiness.DTOLayer.CommentDTOs;

namespace MicroMultiBusiness.WebUI.Services.CommentServices
{
    public interface ICommentService
    {
        Task<List<ResultCommentDTO>> GetAllCommentsAsync();
        Task CreateCommentAsync(CreateCommentDTO createCommentDTO);
        Task UpdateCommentAsync(UpdateCommentDTO updateCommentDTO);
        Task DeleteCommentAsync(string id);
        Task<UpdateCommentDTO> GetByIdCommentAsync(string id);
        Task<List<ResultCommentDTO>> CommentListByProductId(string id);
    }
}
