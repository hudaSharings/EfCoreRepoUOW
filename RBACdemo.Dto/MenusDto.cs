using System;
using System.Collections.Generic;
using System.Text;

namespace RBACdemo.Dto
{
  public  class MenusDto
    {
        public long id { get; set; }
        public long ParentId { get; set; }
        public string Path { get; set; }
        public string Component { get; set; }
        public List<MenusDto> Child { get; set; }
    }
}
