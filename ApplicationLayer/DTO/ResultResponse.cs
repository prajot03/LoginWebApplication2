using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLayer.DTO
{
    public sealed record ResultResponse<T>
    {
        public bool IsSuccess { get; init; }
        public T? value { get; init; }
        public string? ErrorMsg {  get; init; }

        public static ResultResponse<T> Success(T value)
        {
            ResultResponse<T> response = new ResultResponse<T>() { IsSuccess=true,value=value};

            return response;


        }

        public static ResultResponse<T> Fail(string errorMsg) => new() { ErrorMsg=errorMsg,IsSuccess=false};


    }
}
