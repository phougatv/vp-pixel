﻿namespace VP.Pixel.Core.Persistence.Base;

public interface IUnitOfWork
{
    Int32 Commit();
    TRepository GetRepository<TRepository>();
}