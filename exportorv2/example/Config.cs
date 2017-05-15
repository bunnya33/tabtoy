// Generated by github.com/davyxu/tabtoy
// Version: 2.8.5
// DO NOT EDIT!!
using System.Collections.Generic;

namespace table
{
	
	// Defined in table: Globals
	public enum ActorType
	{
		
		
		Leader = 0, // 唐僧
		
		
		Monkey = 1, // 孙悟空
		
		
		Pig = 2, // 猪八戒
		
		
		Hammer = 3, // 沙僧
	
	}
	
	

	// Defined in table: Config
	
	public partial class Config
	{
	
		public tabtoy.Logger TableLogger = new tabtoy.Logger();
	
		
		/// <summary> 
		/// Sample
		/// </summary>
		public List<SampleDefine> Sample = new List<SampleDefine>(); 
		
		/// <summary> 
		/// Vertical
		/// </summary>
		public List<VerticalDefine> Vertical = new List<VerticalDefine>(); 
		
		/// <summary> 
		/// Exp
		/// </summary>
		public List<ExpDefine> Exp = new List<ExpDefine>(); 
	
	
		#region Index code
	 	Dictionary<long, SampleDefine> _SampleByID = new Dictionary<long, SampleDefine>();
        public SampleDefine GetSampleByID(long ID, SampleDefine def = default(SampleDefine))
        {
            SampleDefine ret;
            if ( _SampleByID.TryGetValue( ID, out ret ) )
            {
                return ret;
            }
			
			if ( def == default(SampleDefine) )
			{
				TableLogger.ErrorLine("GetSampleByID failed, ID: {0}", ID);
			}

            return def;
        }
		Dictionary<string, SampleDefine> _SampleByName = new Dictionary<string, SampleDefine>();
        public SampleDefine GetSampleByName(string Name, SampleDefine def = default(SampleDefine))
        {
            SampleDefine ret;
            if ( _SampleByName.TryGetValue( Name, out ret ) )
            {
                return ret;
            }
			
			if ( def == default(SampleDefine) )
			{
				TableLogger.ErrorLine("GetSampleByName failed, Name: {0}", Name);
			}

            return def;
        }
		Dictionary<int, ExpDefine> _ExpByLevel = new Dictionary<int, ExpDefine>();
        public ExpDefine GetExpByLevel(int Level, ExpDefine def = default(ExpDefine))
        {
            ExpDefine ret;
            if ( _ExpByLevel.TryGetValue( Level, out ret ) )
            {
                return ret;
            }
			
			if ( def == default(ExpDefine) )
			{
				TableLogger.ErrorLine("GetExpByLevel failed, Level: {0}", Level);
			}

            return def;
        }
		
	
		public VerticalDefine GetVertical( )
		{
			return Vertical[0];
		}	
	
		#endregion
		#region Deserialize code
		
		static tabtoy.DeserializeHandler<Config> ConfigDeserializeHandler = new tabtoy.DeserializeHandler<Config>(Deserialize);
		public static void Deserialize( Config ins, tabtoy.DataReader reader )
		{
 			int tag = -1;
            while ( -1 != (tag = reader.ReadTag()))
            {
                switch (tag)
                { 
                	case 0xa0000:
                	{
						ins.Sample.Add( reader.ReadStruct<SampleDefine>(SampleDefineDeserializeHandler) );
                	}
                	break; 
                	case 0xa0001:
                	{
						ins.Vertical.Add( reader.ReadStruct<VerticalDefine>(VerticalDefineDeserializeHandler) );
                	}
                	break; 
                	case 0xa0002:
                	{
						ins.Exp.Add( reader.ReadStruct<ExpDefine>(ExpDefineDeserializeHandler) );
                	}
                	break; 
                }
             }

			
			// Build Sample Index
			for( int i = 0;i< ins.Sample.Count;i++)
			{
				var element = ins.Sample[i];
				
				ins._SampleByID.Add(element.ID, element);
				
				ins._SampleByName.Add(element.Name, element);
				
			}
			
			// Build Exp Index
			for( int i = 0;i< ins.Exp.Count;i++)
			{
				var element = ins.Exp[i];
				
				ins._ExpByLevel.Add(element.Level, element);
				
			}
			
		}
		static tabtoy.DeserializeHandler<Vec2> Vec2DeserializeHandler = new tabtoy.DeserializeHandler<Vec2>(Deserialize);
		public static void Deserialize( Vec2 ins, tabtoy.DataReader reader )
		{
 			int tag = -1;
            while ( -1 != (tag = reader.ReadTag()))
            {
                switch (tag)
                { 
                	case 0x10000:
                	{
						ins.X = reader.ReadInt32();
                	}
                	break; 
                	case 0x10001:
                	{
						ins.Y = reader.ReadInt32();
                	}
                	break; 
                }
             }

			
		}
		static tabtoy.DeserializeHandler<Prop> PropDeserializeHandler = new tabtoy.DeserializeHandler<Prop>(Deserialize);
		public static void Deserialize( Prop ins, tabtoy.DataReader reader )
		{
 			int tag = -1;
            while ( -1 != (tag = reader.ReadTag()))
            {
                switch (tag)
                { 
                	case 0x10000:
                	{
						ins.HP = reader.ReadInt32();
                	}
                	break; 
                	case 0x50001:
                	{
						ins.AttackRate = reader.ReadFloat();
                	}
                	break; 
                	case 0x80002:
                	{
						ins.ExType = reader.ReadEnum<ActorType>();
                	}
                	break; 
                }
             }

			
		}
		static tabtoy.DeserializeHandler<SampleDefine> SampleDefineDeserializeHandler = new tabtoy.DeserializeHandler<SampleDefine>(Deserialize);
		public static void Deserialize( SampleDefine ins, tabtoy.DataReader reader )
		{
 			int tag = -1;
            while ( -1 != (tag = reader.ReadTag()))
            {
                switch (tag)
                { 
                	case 0x20000:
                	{
						ins.ID = reader.ReadInt64();
                	}
                	break; 
                	case 0x60001:
                	{
						ins.Name = reader.ReadString();
                	}
                	break; 
                	case 0x10002:
                	{
						ins.IconID = reader.ReadInt32();
                	}
                	break; 
                	case 0x50003:
                	{
						ins.NumericalRate = reader.ReadFloat();
                	}
                	break; 
                	case 0x10004:
                	{
						ins.ItemID = reader.ReadInt32();
                	}
                	break; 
                	case 0x10005:
                	{
						ins.BuffID.Add( reader.ReadInt32() );
                	}
                	break; 
                	case 0x90006:
                	{
						ins.Pos = reader.ReadStruct<Vec2>(Vec2DeserializeHandler);
                	}
                	break; 
                	case 0x80007:
                	{
						ins.Type = reader.ReadEnum<ActorType>();
                	}
                	break; 
                	case 0x10008:
                	{
						ins.SkillID.Add( reader.ReadInt32() );
                	}
                	break; 
                	case 0x90009:
                	{
						ins.SingleStruct = reader.ReadStruct<Prop>(PropDeserializeHandler);
                	}
                	break; 
                	case 0x9000a:
                	{
						ins.StrStruct.Add( reader.ReadStruct<Prop>(PropDeserializeHandler) );
                	}
                	break; 
                }
             }

			
		}
		static tabtoy.DeserializeHandler<PeerData> PeerDataDeserializeHandler = new tabtoy.DeserializeHandler<PeerData>(Deserialize);
		public static void Deserialize( PeerData ins, tabtoy.DataReader reader )
		{
 			int tag = -1;
            while ( -1 != (tag = reader.ReadTag()))
            {
                switch (tag)
                { 
                	case 0x60000:
                	{
						ins.Name = reader.ReadString();
                	}
                	break; 
                	case 0x60001:
                	{
						ins.Type = reader.ReadString();
                	}
                	break; 
                }
             }

			
		}
		static tabtoy.DeserializeHandler<VerticalDefine> VerticalDefineDeserializeHandler = new tabtoy.DeserializeHandler<VerticalDefine>(Deserialize);
		public static void Deserialize( VerticalDefine ins, tabtoy.DataReader reader )
		{
 			int tag = -1;
            while ( -1 != (tag = reader.ReadTag()))
            {
                switch (tag)
                { 
                	case 0x60000:
                	{
						ins.ServerIP = reader.ReadString();
                	}
                	break; 
                	case 0x70001:
                	{
						ins.DebugMode = reader.ReadBool();
                	}
                	break; 
                	case 0x10002:
                	{
						ins.ClientLimit = reader.ReadInt32();
                	}
                	break; 
                	case 0x90003:
                	{
						ins.Peer = reader.ReadStruct<PeerData>(PeerDataDeserializeHandler);
                	}
                	break; 
                	case 0x50004:
                	{
						ins.Float = reader.ReadFloat();
                	}
                	break; 
                	case 0x10005:
                	{
						ins.Token.Add( reader.ReadInt32() );
                	}
                	break; 
                }
             }

			
		}
		static tabtoy.DeserializeHandler<ExpDefine> ExpDefineDeserializeHandler = new tabtoy.DeserializeHandler<ExpDefine>(Deserialize);
		public static void Deserialize( ExpDefine ins, tabtoy.DataReader reader )
		{
 			int tag = -1;
            while ( -1 != (tag = reader.ReadTag()))
            {
                switch (tag)
                { 
                	case 0x10000:
                	{
						ins.Level = reader.ReadInt32();
                	}
                	break; 
                	case 0x10001:
                	{
						ins.Exp = reader.ReadInt32();
                	}
                	break; 
                	case 0x70002:
                	{
						ins.BoolChecker = reader.ReadBool();
                	}
                	break; 
                	case 0x80003:
                	{
						ins.Type = reader.ReadEnum<ActorType>();
                	}
                	break; 
                }
             }

			
		}
		#endregion
	

	} 

	// Defined in table: Globals
	
	public partial class Vec2
	{
	
		
		
		public int X = 0; 
		
		
		public int Y = 0; 
	
	

	} 

	// Defined in table: Sample
	[System.Serializable]
	public partial class Prop
	{
	
		
		
		public int HP = 10; // 血量
		
		
		public float AttackRate = 0f; // 攻击速率
		
		
		public ActorType ExType = ActorType.Leader; // 额外类型
	
	

	} 

	// Defined in table: Sample
	[System.Serializable]
	public partial class SampleDefine
	{
	
		
		/// <summary> 
		/// 唯一ID
		/// </summary>
		public long ID = 0; 
		
		/// <summary> 
		/// 名称
		/// </summary>
		public string Name = ""; 
		
		/// <summary> 
		/// 图标ID
		/// </summary>
		public int IconID = 0; 
		
		/// <summary> 
		/// 攻击率
		/// </summary>
		public float NumericalRate = 0f; 
		
		/// <summary> 
		/// 物品id
		/// </summary>
		public int ItemID = 100; 
		
		/// <summary> 
		/// BuffID
		/// </summary>
		public List<int> BuffID = new List<int>(); 
		
		
		public Vec2 Pos = new Vec2(); 
		
		/// <summary> 
		/// 类型
		/// </summary>
		public ActorType Type = ActorType.Leader; 
		
		/// <summary> 
		/// 技能ID列表
		/// </summary>
		public List<int> SkillID = new List<int>(); 
		
		/// <summary> 
		/// 单结构解析
		/// </summary>
		public Prop SingleStruct = new Prop(); 
		
		/// <summary> 
		/// 字符串结构
		/// </summary>
		public List<Prop> StrStruct = new List<Prop>(); 
	
	

	} 

	// Defined in table: Vertical
	
	public partial class PeerData
	{
	
		
		
		public string Name = ""; // 名字
		
		
		public string Type = ""; // 类型
	
	

	} 

	// Defined in table: Vertical
	
	public partial class VerticalDefine
	{
	
		
		/// <summary> 
		/// 服务器IP
		/// </summary>
		public string ServerIP = ""; 
		
		/// <summary> 
		/// 调试模式
		/// </summary>
		public bool DebugMode = false; 
		
		/// <summary> 
		/// 客户端人数限制
		/// </summary>
		public int ClientLimit = 0; 
		
		/// <summary> 
		/// 端
		/// </summary>
		public PeerData Peer = new PeerData(); 
		
		
		public float Float = 0.5f; 
		
		
		public List<int> Token = new List<int>(); 
	
	

	} 

	// Defined in table: Exp
	
	public partial class ExpDefine
	{
	
		
		/// <summary> 
		/// 唯一ID
		/// </summary>
		public int Level = 0; 
		
		/// <summary> 
		/// 经验值
		/// </summary>
		public int Exp = 0; 
		
		/// <summary> 
		/// 布尔检查
		/// </summary>
		public bool BoolChecker = false; 
		
		/// <summary> 
		/// 类型
		/// </summary>
		public ActorType Type = ActorType.Leader; 
	
	

	} 

}
