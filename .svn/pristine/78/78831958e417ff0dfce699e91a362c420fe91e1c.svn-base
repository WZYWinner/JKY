using System;
using System.Linq;
using System.Web;
using Yaohuasoft.Framework.DAL;
using Yaohuasoft.Framework.BLL;
using Yaohuasoft.Framework.Library;
using System.Xml;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;


namespace Yaohuasoft.Framework.Web
{
    /// <summary>
    /// Handler1 的摘要说明
    /// </summary>
    public class MSignHandler : BaseHanlder
    {

        protected override void ExecuteRequest(HttpContext context)
        {           
            try {
                var type = request["type"] ?? "";
                if (type.IsNullOrEmptys())
                {
                    throw new Exception("参数不能为空");
                }
                switch (type)
                {
                    //签到
                    case "Sign":
                        {
                            #region 点击签到，将签到记录保存到数据库中                            
                            //获取用户名
                            string UserId = request["UserId"] ?? "";                           
                            if (UserId.IsNullOrEmptys())
                            {
                                throw new Exception("用户信息不能为空！");
                            }
                            //获取当前时间
                            DateTime SignTime = DateTime.Now;

                            //判断今天是否已签到
                            SignInprizeQueryParameter MySignParm = new SignInprizeQueryParameter();
                            MySignParm.EqualTo.SignTime = DateTime.Today;
                            var MyentityDal = SignInprizeDAL.Select(0, MySignParm).FirstOrDefault();
                            if (!MyentityDal.IsNullOrEmptys())
                            {
                                throw new Exception("今天已经签到过了！");
                            }
                            string sql1 = SystemConfig.SQL;
                            //判断用户名是否存在
                            UserInfoQueryParameter UserParm = new UserInfoQueryParameter();
                            UserParm.EqualTo.Id = UserId;
                            var userInfoEntity = UserInfoDAL.Select(0, UserParm).FirstOrDefault();
                            if (userInfoEntity.IsNullOrEmptys())
                            {
                                throw new Exception("未找到此用户！");
                            }
                            SignInprizeQueryParameter SignParm = new SignInprizeQueryParameter();
                            SignParm.EqualTo.Id = UserId;                          
                            var entity = new SignInprizeDALEntity();
                            //向表添加签到时间 先存
                            //现在签到时间
                            entity.SignTime = Convert.ToDateTime(SignTime);
                            //用户ID
                            entity.UserId = UserId;
                            #region 连续签到判断

                            //查找该用户签到表 是否存在昨天 年 月 日 的时间  
                            SignInprizeQueryParameter SignParm1 = new SignInprizeQueryParameter();
                            SignParm1.GreatEqual.SignTime = DateTime.Today.AddDays(-1);
                            var entityDal = SignInprizeDAL.Select(0, SignParm1).FirstOrDefault();
                            string sql = SystemConfig.SQL;

                            //无则 连续签到天数 = 1
                            if (entityDal.IsNullOrEmptys())
                            {
                                entity.ContinuityDay = 1;
                            }

                            //有则连续签到天数+1  最多连续7天
                            if (entity.ContinuityDay >= 7)
                            {
                                entity.ContinuityDay = 7;
                            }                         
                            entity.ContinuityDay = entityDal.ContinuityDay + 1;
                            //总天数加一
                            entity.SignDayCount = entity.SignDayCount + 1;
                            #endregion

                           //总积分 = 连续签到总天数*10 
                           //判断 连续签到天数-7 >= 0 积分=7*10
                           //判断 连续签到天数-7 < 0 则 积分 = 连续签到天数*10
                            #region 积分添加判断

                           //积分计算
                           int num = Convert.ToInt32(entity.ContinuityDay - 7);
                            if (entity.ContinuityDay < 0)
                            {
                                entity.SignCount = entity.SignCount + 70;
                            }
                            else
                            {
                                entity.SignCount = entity.SignCount + entity.ContinuityDay * 10;
                            }
                            //积分等级划分 暂时只有两个等级划分
                            if (entity.SignCount >= 100)
                            {
                                entity.SignGrade = 2;
                            }
                            else {
                                entity.SignGrade = 1;
                            }
                            #endregion

                            //更新数据库
                            SignInprizeDAL.Merge(0, entity);

                            output = JsonSerializer.Serialize(new { result_state = true ,msg="签到成功"});

                            #endregion
                        }
                        break;
                    //获取签到历史   
                    case "GetSign":
                        {
                            #region 获取签到记录
                            //获取用户名
                            string UserId = request["UserId"] ?? "";
                            if (UserId.IsNullOrEmptys())
                            {
                                throw new Exception("用户信息不能为空！");
                            }
                            //判断用户名是否存在
                            UserInfoQueryParameter UserParm = new UserInfoQueryParameter();
                            UserParm.EqualTo.Id = UserId;
                            var userInfoEntity = UserInfoDAL.Select(0, UserParm).FirstOrDefault();
                            if (userInfoEntity.IsNullOrEmptys())
                            {
                                throw new Exception("未找到此用户！");
                            }
                            #region 获取该用户的签到信息
                            SignInprizeQueryParameter parm = new SignInprizeQueryParameter();
                            parm.EqualTo.Id = UserId;
                            // 积分等级 总积分 连续签到天数 签到总天数 只要获取第一个最新的就好
                            var entity = SignInprizeDAL.Select(0, parm).FirstOrDefault();
                            if (entity.IsNullOrEmptys())
                            {
                                throw new Exception("尚未有此用户签到信息！");
                            }
                            var entity2 = new SignEntity();
                            //获取用户签到等级 总天数 连续签到天数
                            List<SignEntity> list = new List<SignEntity>();
                            entity2.SignGrade = Convert.ToInt32(entity.SignGrade);
                            entity2.SignCount = Convert.ToInt32(entity.SignCount);
                            entity2.SignDayCount = Convert.ToInt32(entity.SignDayCount);
                            list.Add(entity2);
                           
                            //获取 该用户下所有的签到时间
                            var entity3 = SignInprizeDAL.Select(0, parm);
                            if (entity3.IsNullOrEmptys())
                            {
                                throw new Exception("尚未有此用户签到信息！");
                            }
                            List<SignEntity> list2 = new List<SignEntity>();
                            foreach (var item in entity3)
                            {
                                var entity4 = new SignEntity();
                                entity4.SignTime = Convert.ToDateTime(item.SignTime);
                                list2.Add(entity4);
                            }
                            #endregion
                            
                            output = JsonSerializer.Serialize(new { result_state = true ,list , list2 });
                            #endregion
                        }
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                 output = JsonSerializer.Serialize(new { result_state = false, msg=ex.Message });
            }
        }

        public class SignEntity
        {
            #region 签到实体
            public string ID { get; set; }//ID
            public string UserName { get; set; }//用户名
            public int  SignGrade { get; set; }//积分等级 表示单次积分增加量
            public int SignCount { get; set; }//总积分
            public int ContinuityDay { get; set; }//连续签到天数
            public int SignDayCount { get; set; }//签到总天数
            public DateTime SignTime { get; set; }//签到时间
            #endregion
        }
    }
}