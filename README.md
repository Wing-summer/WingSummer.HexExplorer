# WingSummer.PEHexExplorer

#### 介绍
本软件由纯C#编写，基于我改良的Be.Windows.Forms.HexBox组件( https://gitee.com/wingsummer/be.-windows.-forms.-hex-box )【MIT协议】。目的是方便专业人士修改分析PE文件，并可作为学习PE结构的重要辅助工具。

#### 软件架构

1. Be.Windows.Forms.HexBox ：本组件由我改良的十六进制编辑组件Be.Windows.Forms.HexBox进一步增进使用，增加支持水平滚动条和一些其他接口（例如填充支持撤销恢复更改的数据接口）和代码整理，详情请看代码，现组件遵循本仓库的协议。
2. PEProcesser ：解析PE结构的重要组件，由本人编写，由于本人知识限制，dot平台的PE结构可能支持不完善，普通PE文件有些查询接口未编写封装，欢迎 issue 或者 pull request，本组件遵循本仓库协议。
3. PEHexExplorer ：本软件的主程序，提供GUI交互，遵循本仓库协议。

#### 使用声明

1.  本软件是为方便专业人士快速编辑定位PE文件的结构，同时也便于本人巩固或者学习PE知识以及C#编程。也可以作为初学者学习PE结构的重要辅助工具。
2.  本软件仅供学习交流使用，不得私自用于商业用途。如需将本软件某些部分用于商业用途，必须找我授权。
3.  本人学生，由于本软件是用我的业余时间编写，不能及时修复Bug或者提供技术支持，请见谅。
4.  本人非专业计算机，编写程序难免有Bug，欢迎提交 issue 。

#### 参与贡献

1.  如果您有想参与本软件代码开发递交，请在 pull request 联系我。
2.  本项目支持捐助，如有意愿请到本仓库通过微信或者支付宝的方式进行，本人不喝奶茶，一瓶水的价钱足以提高我的维护该项目的热情，感谢大家的支持。
3.  如果您想提交修复或者增进程序的代码，请在 pull request 递交。
4.  任何成功参与代码Bug修复以及增进程序功能的同志和Sponsor，都会在本仓库ReadMe和附属说明文件中体现，您如果是其中之一，本人可以按照您合理的意愿来进行说明。


#### 效果图




#### 捐助

<p align="center">

<img alt="支付宝" src="pics/支付宝捐助.jpg" height=50% width=50%>
<p align="center">感谢支持</p>

</p>

<p align="center">
<img alt="微信" src="pics/微信捐助.png" height=50% width=50%>
<p align="center">感谢支持</p>

</p>