﻿
using System;
using System.Collections.Generic;
using YouLearn.Domain.Arguments.Base;
using YouLearn.Domain.Arguments.Video;
using YouLearn.Domain.Interfaces.Services.Base;

namespace YouLearn.Domain.Interfaces.Services
{
    public interface IServiceVideo: IServiceBase
    {       
        AdicionarVideoResponse AdicionarVideo(AdicionarVideoRequest request, Guid id);
        IEnumerable<VideoResponse> Listar(string tags);
        IEnumerable<VideoResponse> Listar(Guid idPlayList);
      
    }
}
