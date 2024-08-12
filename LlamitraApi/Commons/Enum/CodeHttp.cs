﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LlamitraApi.Commons.Enum
{
    public enum CodeHttp
    {
        OK = 200,
        CREATED = 201,
        ACCEPTED = 202,
        NOCONTENT = 204,
        REDIRECT = 302,
        UNAUTHORIZED = 401,
        BADREQUEST = 400,
        NOTFOUND = 404,
        FORBIDDEN = 403,
        CONFLICT = 409,
        INTERNALSERVER = 500,
    }
}
