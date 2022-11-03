﻿using Application.Common.Responses;

namespace Application.Interfaces;
public interface IResponse<T>
{
    T Data { get; set; }

    string Description { get; set; }

    StatusCode StatusCode { get; set; }
}
