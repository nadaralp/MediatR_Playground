﻿using System;
using System.Collections.Generic;
using System.Text;

namespace MediatorTut.Services
{
    public static class Response
    {
        public static Response<T> Fail<T>(string message, T data = default)
            => new Response<T>(data, message, true);

        public static Response<T> Ok<T>(T data, string message)
            => new Response<T>(data, message, false);
    }

    public class Response<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; }

        public Response(T data, string message, bool error)
        => (Data, Message, Error) = (data, message, error);

        
    }
}
