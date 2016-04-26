<%@ page language="java" contentType="text/html; charset=utf-8"
    pageEncoding="utf-8"%>
<!DOCTYPE html PUBLIC "-//W3C//DTD HTML 4.01 Transitional//EN" "http://www.w3.org/TR/html4/loose.dtd">
<html>
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
<title>生成增量包</title>
</head>
<body>
 <form action=ApplyPatch method="post">
      <center>
        <table  style=" margin-top: 100px">
        	<tr><td><a href="GenPatch.jsp" style="float:right;">生成增量包</a></td></tr>
            <tr>
                <td>请选择目标文件：</td>
                <td> <input type="file" name="oldFile" size="20" /></td>
            </tr>
             <tr>
                <td>请选择增量文件:</td>
                <td><input type="file" name="newFile" size="20" /></td>
            </tr>
             <tr >
                <td align="center" colspan="2" >
                <input type="submit" value="应用增量包"/>
                </td>
            </tr>
        </table>        
      
      </center>
      </form>
</body>
</html>