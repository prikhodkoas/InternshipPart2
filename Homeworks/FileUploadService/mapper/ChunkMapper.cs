using DataBase.Model;
using FileUploadService.dto;

namespace FileUploadService.mapper
{
    internal class ChunkMapper : IMapper<ChunkDto, Chunk>
    {
        public ChunkDto ToDto(Chunk entity)
        {
            return new ChunkDto()
            {
                FileId = entity.FileId,
                NumberInSequence = entity.NumberInSequence,
                Content = entity.Content
            };
        }

        public Chunk ToEntity(ChunkDto dto)
        {
            return new Chunk()
            {
                FileId = dto.FileId,
                NumberInSequence = dto.NumberInSequence,
                Content = dto.Content
            };
        }
    }
}
