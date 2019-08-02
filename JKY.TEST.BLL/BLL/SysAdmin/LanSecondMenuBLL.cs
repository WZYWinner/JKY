using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using Yaohuasoft.Framework.Library;
using Yaohuasoft.Framework.DAL;
using System.Data;
using System.Text;
namespace Yaohuasoft.Framework.BLL.SysAdmin
{
public static partial class LanSecondMenuBLL
{
/// <summary>
/// 新增
/// </summary>
/// <returns>执行结果</returns>
public static int Add(LanSecondMenuDALEntity entity,string corpId,string departmentId,string userName)
{
var ret = 0;
entity.LanMenuId = departmentId;
ret = LanSecondMenuDAL.Merge(0, entity,0);
////调试用SQL
string sql=SystemConfig.SQL;
return ret;
}
/// <summary>
/// 新增
/// </summary>
/// <returns>执行结果</returns>
public static int Merge(LanSecondMenuDALEntity entity,string corpId,string departmentId,string userName)
{
var ret = 0;
entity.LanMenuId = departmentId;
ret = LanSecondMenuDAL.Merge(0, entity,0);
////调试用SQL
string sql=SystemConfig.SQL;
return ret;
}
/// <summary>
/// 根据ID删除单个实体
/// </summary>
/// <returns>执行结果</returns>
public static int Delete(string id,string corpId,string departmentId,string userName)
{
var ret = 0;
//验证ID
if (string.IsNullOrEmpty(id.ToStr()))
return ret;
//实体赋值获取
ret = LanSecondMenuDAL.Delete(0, id,0);
return ret;
}
/// <summary>
/// 修改
/// </summary>
/// <returns>执行结果</returns>
public static int Save(LanSecondMenuDALEntity entity,string corpId,string departmentId,string userName)
{
var ret = 0;
//验证名称
if (string.IsNullOrEmpty(entity.LanSecondMenuId.ToStr()))
return ret;
ret = LanSecondMenuDAL.Update(0, entity,0);
return ret;
}
/// <summary>
/// 根据ID获取单个实体
/// </summary>
public static LanSecondMenuDALEntity GetEntity(string id,string corpId,string departmentId,string userName)
{
//验证ID
if (string.IsNullOrEmpty(id.ToStr()))
return null;
//实体获取
var entity = LanSecondMenuDAL.Select(0, id,0);
////添加附加按钮代码
entity=GetCustomCode(entity);
return entity;
}
public static void DealCustomCode(string id, string btnId)
{
////入参判断
if (id.IsNullOrEmptys() || btnId.IsNullOrEmptys())
return;
var entity = GetEntity(id.ToString(), null, null, null);
if (entity == null) return;
switch (btnId)
{
default:
break;
}
}
public static LanSecondMenuDALEntity GetCustomCode( LanSecondMenuDALEntity entity)
{
if(entity==null)return null;
////自定义按钮的业务代码
entity._CustomCode=new YaohuaDict<string,string>();
List<string> sb ;
//////////////////////////////////////////////////////////////
////LIST业务逻辑代码
sb=new List<string>();
entity._CustomCode.Add("LIST", YaohuaCollection<string>.ToString(sb, " | "));
//////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////
////DETAIL业务逻辑代码
sb=new List<string>();
entity._CustomCode.Add("DETAIL", YaohuaCollection<string>.ToString(sb, ""));
//////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////
////CREATE业务逻辑代码
sb=new List<string>();
entity._CustomCode.Add("CREATE", YaohuaCollection<string>.ToString(sb, ""));
//////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////
////MODIFY业务逻辑代码
sb=new List<string>();
entity._CustomCode.Add("MODIFY", YaohuaCollection<string>.ToString(sb, ""));
//////////////////////////////////////////////////////////////
return entity;
}
/// <summary>
/// 根据所有者获取列表
/// </summary>
/// <param name="userid">用户ID</param>
/// <param name="pindex">页码</param>
/// <param name="psize">页大小</param>
/// <param name="count">列表统计</param>
/// <returns>项目实体列表</returns>
public static List<LanSecondMenuDALEntity> GetList( YaohuaDict<string, string> dropList,
YaohuaDict<string, string> textBox,YaohuaDict<string, string> textBoxInOne, YaohuaDict<string, string> sortList,
int CurrentPageIndex, int PageSize,string corpId,string departmentId,string userName, out int count)
{
var list = new List<LanSecondMenuDALEntity>();
count = 0;
//查询实体赋值
var parm = new LanSecondMenuQueryParameter();
parm.Pager.PageIndex = CurrentPageIndex-1;//数据从索引0开始
parm.Pager.OnePageSize = PageSize;
////通过主表ID取附表
if (textBox["LanMenuId"].IsNullOrEmptys()==false)parm.EqualTo.LanMenuId = textBox["LanMenuId"].ToString();
//统计查询 分页使用
count = LanSecondMenuDAL.Count(0, parm,0);
//数据库查询
list = LanSecondMenuDAL.Select(0, parm,0).ToList();
////调试用SQL
string sql=SystemConfig.SQL;
///////////////////////////////
var list2 = new List<LanSecondMenuDALEntity>();
for (int i = 0; i < list.Count; i++)
{
LanSecondMenuDALEntity entity = list[i].Clone();
////添加附加按钮代码
entity=GetCustomCode(entity);
list2.Add(entity);
}
return list2;
}
/// <summary>
/// 根据所有者获取列表
/// </summary>
/// <param name="userid">用户ID</param>
/// <param name="pindex">页码</param>
/// <param name="psize">页大小</param>
/// <param name="count">列表统计</param>
/// <returns>项目实体列表</returns>
public static List<LanSecondMenuDALEntity> GetList4Export( YaohuaDict<string, string> dropList,
YaohuaDict<string, string> textBox,YaohuaDict<string, string> textBoxInOne, YaohuaDict<string, string> sortList
,string corpId,string departmentId,string userName, out int count)
{
var list = new List<LanSecondMenuDALEntity>();
count = 0;
//查询实体赋值
var parm = new LanSecondMenuQueryParameter();
parm.Pager.PageIndex = 0;//数据从索引0开始
parm.Pager.OnePageSize = OnePageSize4Export;
////通过主表ID取附表
if (textBox["LanMenuId"].IsNullOrEmptys()==false)parm.EqualTo.LanMenuId = textBox["LanMenuId"].ToString();
//统计查询 分页使用
count = LanSecondMenuDAL.Count(0, parm,0);
//排序
parm.OrderBy.Add("LanSecondMenuId", YaohuaOrderByType.Desc);
//数据库查询
list = LanSecondMenuDAL.Select(0, parm,0).ToList();
////调试用SQL
string sql=SystemConfig.SQL;
///////////////////////////////
var list2 = new List<LanSecondMenuDALEntity>();
for (int i = 0; i < list.Count; i++)
{
LanSecondMenuDALEntity entity = list[i].Clone();
list2.Add(entity);
}
return list2;
}
 private static YaohuaDict<string, StringBuilder> dict = new YaohuaDict<string, StringBuilder>();
 public static void WriteImprtLog(string TaskId)
 {
 if (dict.ContainsKey(TaskId) == false) return;
 StringBuilder sb = dict[TaskId];
 string txt = sb.ToString();
 YaohuaFile.AppendAllText(SystemConfig.RootPath + "/ImportLog/" + TaskId + ".txt", txt);
 dict.Remove(TaskId);
 }
 public static void RecordImportLog(string TaskId, int RowNum, string ErrMsg)
 {
 if (dict.ContainsKey(TaskId) == false) dict.Add(TaskId, new StringBuilder());
 StringBuilder sb = dict[TaskId];
 sb.AppendLine(string.Format("第{0}行：{1}", RowNum.ToString(), ErrMsg));
 }
 public static string ImportExcel2Db(DataTable table, ImportExcelType ImportType, string corpId, string departmentId, string userName)
 {
 if (table == null) return "请选择正确的EXCEL文件！";
 string TaskId = YaohuaID.NewID();
 int TotalCount = table.Rows.Count;
 int OkCount = 0;
 int AuditCount = 0;
 int RowNum = 1;
 LanSecondMenuDALEntity[] list = LanSecondMenuDAL.DataTable2Array4CnName(table, int.MaxValue);
 foreach (var item in list)
 {
 RowNum++;
 if (LanSecondMenuDALEntity.IsEmpty(item) == true) { RecordImportLog(TaskId, RowNum, "空行"); continue; }
 ////解析数据
 LanSecondMenuDALEntity oldEntity = null;
 if (item.LanSecondMenuId != null)
 oldEntity = LanSecondMenuBLL.GetEntity(item.LanSecondMenuId.ToString(), corpId, departmentId, userName);
 switch (ImportType)
 {
 case ImportExcelType.NotExistImport:
 ////如果没有老数据
 if (oldEntity == null)
 {
 ////将新数据写入
 Add(item, corpId, departmentId, userName);
 ////
 OkCount++;
 }
 ////如果有老数据
 else
 {
 }
 break;
 case ImportExcelType.UseImport:
 ////如果没有老数据
 if (oldEntity == null)
 {
 ////将新数据写入
 Add(item, corpId, departmentId, userName);
 ////
 OkCount++;
 }
 ////如果有老数据
 else
 {
 ////将新数据写入
 Save(item, corpId, departmentId, userName);
 ////
 OkCount++;
 }
 break;
 default:
 break;
 }
 }
 int NgCount = TotalCount - OkCount;
 string msg = "";
 msg = "读取" + TotalCount + "条数据";
 if (OkCount > 0) msg += "，成功导入" + OkCount + "条";
 if (NgCount > 0) msg += "，跳过" + NgCount + "条";
 if (AuditCount > 0) msg += "，有" + AuditCount + "条需要审核";
 if (NgCount > 0) msg += "，错误日志：<a target='_blank' href='/ImportLog/"+TaskId+".txt'>查看日志</a>";
 WriteImprtLog(TaskId);
 return msg;
 }
 public static string ImportExcel2Db4Audit(DataTable table, ImportExcelType ImportType, string corpId, string departmentId, string userName)
 {
 if (table == null) return "请选择正确的EXCEL文件！";
 string TaskId = YaohuaID.NewID();
 int TotalCount = table.Rows.Count;
 int OkCount = 0;
 int AuditCount = 0;
 int RowNum = 1;
 LanSecondMenuDALEntity[] list = LanSecondMenuDAL.DataTable2Array4CnName(table, int.MaxValue);
 foreach (var item in list)
 {
 RowNum++;
 if (LanSecondMenuDALEntity.IsEmpty(item) == true) { RecordImportLog(TaskId, RowNum, "空行"); continue; }
 ////解析数据
 LanSecondMenuDALEntity oldEntity = null;
 if (item.LanSecondMenuId != null)
 oldEntity = LanSecondMenuBLL.GetEntity(item.LanSecondMenuId.ToString(), corpId, departmentId, userName);
 switch (ImportType)
 {
 case ImportExcelType.NotExistImport:
 ////如果没有老数据
 if (oldEntity == null)
 {
 ////将新数据写入
 Add(item, corpId, departmentId, userName);
 ////
 OkCount++;
 }
 ////如果有老数据
 else
 {
 }
 break;
 case ImportExcelType.UseImport:
 ////如果没有老数据
 if (oldEntity == null)
 {
 ////将新数据写入
 }
 ////如果有老数据
 else
 {
 }
 break;
 default:
 break;
 }
 }
 int NgCount = TotalCount - OkCount;
 string msg = "";
 msg = "读取" + TotalCount + "条数据";
 if (OkCount > 0) msg += "，成功导入" + OkCount + "条";
 if (NgCount > 0) msg += "，跳过" + NgCount + "条";
 if (AuditCount > 0) msg += "，有" + AuditCount + "条需要审核";
 if (NgCount > 0) msg += "，错误日志：<a target='_blank' href='/ImportLog/"+TaskId+".txt'>查看日志</a>";
 WriteImprtLog(TaskId);
 return msg;
 }
/// <summary>
/// 导出时最多导出多少条
/// </summary>
static public int OnePageSize4Export = 10000;
/// <summary>
/// 将实体数组转化为DataTable
/// 取最先N条
/// </summary>
/// <param name="input">数据列表</param>
/// <param name="TopCount">取最先N条</param>
/// <returns></returns>
static public DataTable EntityList2DataTableCn( LanSecondMenuDALEntity[] input)
{
DataTable result = new DataTable();
List<LanSecondMenuDALEntity> list = new List<LanSecondMenuDALEntity>();
////将LIST列表的ID变成名字
foreach (var item in input)
{
////克隆后加入新列表
LanSecondMenuDALEntity entity = item.Clone();
list.Add(entity);
}
////构建DataTable的列
result.Columns.Add("菜单名称", typeof(string));
result.Columns.Add("菜单图标", typeof(string));
result.Columns.Add(" ", typeof(string));
int i = 0;
////填充DataTable的数据
foreach (LanSecondMenuDALEntity item in list)
{
result.Rows.Add(
item.LanSecondMenuName,
item.LanSecondMenuImg,
"");
i++;
}
return result;
}
}
}
