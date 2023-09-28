﻿using Garther.Forum.Database.Entities;

namespace Garther.Forum.Database.Repositories.Interfaces;

public interface ICommentRepository
{
    Task<Comment> GetCommentByIdAsync(Guid id, CancellationToken token);
    Task<IEquatable<Comment>> GetCommentsByTopicAsync(Guid topicId, CancellationToken token);
}