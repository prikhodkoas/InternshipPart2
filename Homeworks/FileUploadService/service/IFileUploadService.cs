using FileUploadService.dto;
using System;
using System.Threading;

namespace FileUploadService.service
{
    public interface IFileUploadService
    {
        Guid CreateFile(FileDto fileDto);
        void UploadChunk(Guid fileId, ChunkDto chunkDto, CancellationToken token);
        void CompleteFileUpload(Guid fileId);
    }
}
