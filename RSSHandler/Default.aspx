<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RSSHandler._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <script src="rsshandler.ashx" type="text/javascript" language="javascript"></script>
        <script src="rsshandler.ashx?feed=http%3A%2F%2Fgitb.com%2Fswtay.atom" type="text/javascript" language="javascript"></script>
        <!-- script src="rsshandler.ashx?feed=http%3A%2F%2Fgithub.com%2Fswattay.atom" type="text/javascript" language="javascript"></script -->
        <script src="rsshandler.ashx?feed=http%3A%2F%2Ffeeds.washingtonpost.com%2Fwp-dyn%2Frss%2Ftechnology%2Findex_xml" type="text/javascript" language="javascript"></script>
    </div>
    </form>
</body>
</html>
