drop proc spPROCESS_DETAIL_SelectByAllId
go
create proc spPROCESS_DETAIL_SelectByAllId
@Code as nvarchar(50)='PA',
@uId_Phong as nvarchar(50)='',
@uId_Step as nvarchar(50)=''
as
begin
	declare @st nvarchar(500)
	begin 
		set @st= 'select ID,qt.uId_Phongban, qt.uId_Step,
		nv_Tenphong_vn, rot.Process_Name, rot.Code,
		step.StepName, step.StepNumb
		from QLP_DM_PHONG dmp, PROCESS_DETAIL qt, PROCESS_ROOT rot, PROCESS_ROOT_STEP step
		where dmp.uId_Phong=qt.uId_Phongban and rot.Code=step.Root_Id and qt.uId_Step=step.uId_Step'
		  
	end
	begin
		if @Code<>''
			set @st+= ' and rot.Code='''+@Code+''''
	end
	begin
		 if @uId_Phong<>''
			set @st+=' and qt.uId_Phongban='''+@uId_Phong+''''
	end
	begin
		if	@uId_Step<>''
			set @st+=' and qt.uId_Step='''+@uId_Step+''''
	end
	begin
		set @st+=' order by Process_Name, StepNumb'
	end
	print @st
	exec(@st)
end
go