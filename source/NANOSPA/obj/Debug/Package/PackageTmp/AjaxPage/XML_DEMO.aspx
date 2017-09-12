<%@ Page language="vb"%>
<%@ Import Namespace="System.XML" %>
<%@ Import Namespace="System.Xml.Linq" %>
<html><head>

  <script language="VB" runat="server" ID=Script1>

	
Sub btnReadXML_OnClick(sender As Object, e As EventArgs)
  'Read and display existing file
          ReadXML(Server.MapPath("applicant.xml"))
End Sub

Sub btnWriteXML_OnClick(sender As Object, e As EventArgs)
   Try
   
   
    Dim enc as Encoding
	'Create file, overwrite if exists
	'enc is encoding object required by constructor
	'It is null, so default encoding is used
              'Dim objXMLTW as new XMLTextWriter(Server.MapPath("applicant.xml"), enc)
              'objXMLTW.WriteStartDocument
              ''Top level (Parent element)
              '             objXMLTW.WriteStartElement("JSChart")

              ''Child elements, from request form
              '             objXMLTW.WriteStartElement("dataset")
              '             objXMLTW.WriteAttributeString("type", "", "line")
              '             objXMLTW.WriteAttributeString("id", "", "gray")
              '             'Begin repeater data
              '             objXMLTW.WriteStartElement("data")
              '             objXMLTW.WriteAttributeString("unit", "", "1")
              '             objXMLTW.WriteAttributeString("value", "", "100")
              '             objXMLTW.WriteEndElement()
              '             'End repeater data
              '             objXMLTW.WriteEndElement()

              '             objXMLTW.WriteStartElement("optionset")
              '             'Begin option set
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setSize")
              '             objXMLTW.WriteAttributeString("value", "", "950, 250")
              '             objXMLTW.WriteEndElement()
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setAxisValuesNumberY")
              '             objXMLTW.WriteAttributeString("value", "", "5")
              '             objXMLTW.WriteEndElement()
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setIntervalStartY")
              '             objXMLTW.WriteAttributeString("value", "", "0")
              '             objXMLTW.WriteEndElement()
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setIntervalEndY")
              '             objXMLTW.WriteAttributeString("value", "", "500")
              '             objXMLTW.WriteEndElement()
              '             'Begin repeater label
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setLabelX")
              '             objXMLTW.WriteAttributeString("value", "", "[1,'1']")
              '             objXMLTW.WriteEndElement()
              '             'End repeater label
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setAxisValuesNumberX")
              '             objXMLTW.WriteAttributeString("value", "", "5")
              '             objXMLTW.WriteEndElement()
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setShowXValues")
              '             objXMLTW.WriteAttributeString("value", "", "false")
              '             objXMLTW.WriteEndElement()
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setTitleColor")
              '             objXMLTW.WriteAttributeString("value", "", "'#454545'")
              '             objXMLTW.WriteEndElement()
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setAxisValuesColor")
              '             objXMLTW.WriteAttributeString("value", "", "'#454545'")
              '             objXMLTW.WriteEndElement()
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setLineColor")
              '             objXMLTW.WriteAttributeString("value", "", "'#FEA500', 'gray'")
              '             objXMLTW.WriteEndElement()
              '             'Begin repeater tooltip
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setTooltip")
              '             objXMLTW.WriteAttributeString("value", "", "[1,' ']")
              '             objXMLTW.WriteEndElement()
              '             'End repeater tooltip
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setFlagColor")
              '             objXMLTW.WriteAttributeString("value", "", "'#3C8DBC'")
              '             objXMLTW.WriteEndElement()
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setFlagRadius")
              '             objXMLTW.WriteAttributeString("value", "", "4")
              '             objXMLTW.WriteEndElement()
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setAxisPaddingRight")
              '             objXMLTW.WriteAttributeString("value", "", "100")
              '             objXMLTW.WriteEndElement()
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setLegendShow")
              '             objXMLTW.WriteAttributeString("value", "", "true")
              '             objXMLTW.WriteEndElement()
              '             objXMLTW.WriteStartElement("option")
              '             objXMLTW.WriteAttributeString("set", "", "setLegendPosition")
              '             objXMLTW.WriteAttributeString("value", "", "490, 80")
              '             objXMLTW.WriteEndElement()

              '             'End option set
              '             objXMLTW.WriteEndElement()

              'objXMLTW.WriteEndElement 'End top level element
              'objXMLTW.WriteEndDocument 'End Document
              'objXMLTW.Flush 'Write to file
              'objXMLTW.Close
              ''Display File Just Created
              'ReadXML(Server.MapPath("applicant.xml"))
              Dim doc As XDocument = XDocument.Load(Server.MapPath("customer.xml"))
              doc.Descendants("data").Last().AddAfterSelf(New XElement("data", New XAttribute("unit", "2"), New XAttribute("value", "100")))
              doc.Descendants("data").Skip(1).Remove()
              doc.Save(Server.MapPath("customer.xml"))
	        
	  Catch Ex as Exception
		lblXMLFile.Text = "The following error occurred: " & Ex.Message
   End Try
End Sub

Sub ReadXML(FileName as String)
Try

lblXMLFile.Text =""
Dim objXMLTR as new  XMLTextReader(FileName)
dim sCategory as String
dim bNested as Boolean
dim sLastElement as String
Dim sValue as String

'Read method loops through the XML stream
Do While objXMLTR.Read

'Output elements and values
'Look at output in browser and compare to menu.xml file to 
'see exactly what is being done
		If objXMLTR.NodeType = XMLNodeType.Element Then
			 if bNested = True  then
			    if sCategory <> "" then sCategory = sCategory & " > "  
			    sCategory = sCategory &  sLastElement
			 End if 
			  bNested = True
			 sLastElement = objXMLTR.Name
			 
		Else If objXMLTR.NodeType = XMLNodeType.Text or _
		  objXMLTR.NodeType = XMLNodeType.CData Then
			bNested = False
			sCategory = "<P>" & sCategory
			sValue = objXMLTR.value 
			 lblXMLFile.Text  = lblXMLFile.Text & "<B>" & sCategory & _
			    "<BR>" &  sLastElement & "</B><BR>" &  sValue 
			 sLastElement = ""
		     sCategory = ""
		End if
	Loop
	objXMLTR.close
Catch Ex as Exception
	lblXMLFile.Text = "The following error occurred: " & Ex.Message
End Try

End Sub
  </script>
</head>
<body>
<center><b>XML Text Reader/Text Writer Demo</b></center>
<form method="post" action="XML_DEMO.aspx" runat="server" ID=Form1>

 <table WIDTH = "100%">
	<tr>
	<TD width="50%" valign = top>
		Click below to read/parse the file "menu.xml".<p>
		<asp:Button id="btnReadXML" text="Read XML Document" OnClick="btnReadXML_onClick" runat="server" /><p>
	<asp:label id="lblXMLFile" runat="server" /></p>
	
	</TD>

	<TD width="50%" valign = top>
	Complete the fields below to create and display the XML file "applicant.xml" (write permission for the Internet Anonymous user must be enabled)<P>
	
	<asp:Button id="btnWriteXML" text="Write XML Document" OnClick="btnWriteXML_onClick" runat="server" /><p><strong>Applicant</strong>
      <p><table><tr><td>
      Name:</td> 
<td><asp:Textbox id=txtName runat="server" width="200" 
      visible="True"></asp:Textbox></td></tr>
      <tr><td>Address: </td> 
<td>
	
	<asp:Textbox id="txtAddress" runat="server"  visible="True" width="200"/></td></tr>
      <tr><td>
      City: </td> 
<td>
<asp:Textbox id=txtCity runat="server" width="200" 
      visible="True"></asp:Textbox></td></tr>
      <tr><td>
      State: </td> 
<td>
<asp:Textbox id=txtState runat="server" width="200" visible="True" 
      MaxLength="2"></asp:Textbox></td></tr>
      <tr><td>
      Zip: </td> 
<td>
<asp:Textbox id=txtZip runat="server" width="200" 
      visible="True" maxlength="10"></asp:Textbox></td></tr>
     
	
	</table></p>
	</TD>
	</tr>
</table>
 </form>
  


 </body></html>
