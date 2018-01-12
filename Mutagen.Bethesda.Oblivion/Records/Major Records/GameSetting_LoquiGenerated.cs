/*
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
 * Autogenerated by Loqui.  Do not manually change.
 * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * 
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loqui;
using Noggog;
using Noggog.Notifying;
using Mutagen.Bethesda.Oblivion.Internals;
using Mutagen.Bethesda;
using Mutagen.Bethesda.Internals;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Noggog.Xml;
using Loqui.Xml;
using System.Diagnostics;
using Mutagen.Bethesda.Binary;

namespace Mutagen.Bethesda.Oblivion
{
    #region Class
    public abstract partial class GameSetting : MajorRecord, IGameSetting, ILoquiObjectSetter, IEquatable<GameSetting>
    {
        ILoquiRegistration ILoquiObject.Registration => GameSetting_Registration.Instance;
        public new static GameSetting_Registration Registration => GameSetting_Registration.Instance;

        #region Ctor
        public GameSetting()
        {
            CustomCtor();
        }
        partial void CustomCtor();
        #endregion


        #region Loqui Getter Interface

        protected override object GetNthObject(ushort index) => GameSettingCommon.GetNthObject(index, this);

        protected override bool GetNthObjectHasBeenSet(ushort index) => GameSettingCommon.GetNthObjectHasBeenSet(index, this);

        protected override void UnsetNthObject(ushort index, NotifyingUnsetParameters? cmds) => GameSettingCommon.UnsetNthObject(index, this, cmds);

        #endregion

        #region Loqui Interface
        protected override void SetNthObjectHasBeenSet(ushort index, bool on)
        {
            GameSettingCommon.SetNthObjectHasBeenSet(index, on, this);
        }

        #endregion

        #region To String
        public override string ToString()
        {
            return GameSettingCommon.ToString(this, printMask: null);
        }

        public string ToString(
            string name = null,
            GameSetting_Mask<bool> printMask = null)
        {
            return GameSettingCommon.ToString(this, name: name, printMask: printMask);
        }

        public override void ToString(
            FileGeneration fg,
            string name = null)
        {
            GameSettingCommon.ToString(this, fg, name: name, printMask: null);
        }

        #endregion

        public new GameSetting_Mask<bool> GetHasBeenSetMask()
        {
            return GameSettingCommon.GetHasBeenSetMask(this);
        }
        #region Equals and Hash
        public override bool Equals(object obj)
        {
            if (!(obj is GameSetting rhs)) return false;
            return Equals(rhs);
        }

        public bool Equals(GameSetting rhs)
        {
            if (rhs == null) return false;
            if (!base.Equals(rhs)) return false;
            return true;
        }

        public override int GetHashCode()
        {
            int ret = 0;
            ret = ret.CombineHashCode(base.GetHashCode());
            return ret;
        }

        #endregion


        #region XML Translation
        #region XML Copy In
        public override void CopyIn_XML(
            XElement root,
            NotifyingFireParameters? cmds = null)
        {
            LoquiXmlTranslation<GameSetting, GameSetting_ErrorMask>.Instance.CopyIn(
                root: root,
                item: this,
                skipProtected: true,
                doMasks: false,
                mask: out var errorMask,
                cmds: cmds);
        }

        public virtual void CopyIn_XML(
            XElement root,
            out GameSetting_ErrorMask errorMask,
            NotifyingFireParameters? cmds = null)
        {
            LoquiXmlTranslation<GameSetting, GameSetting_ErrorMask>.Instance.CopyIn(
                root: root,
                item: this,
                skipProtected: true,
                doMasks: true,
                mask: out errorMask,
                cmds: cmds);
        }

        public void CopyIn_XML(
            string path,
            NotifyingFireParameters? cmds = null)
        {
            var root = XDocument.Load(path).Root;
            this.CopyIn_XML(
                root: root,
                cmds: cmds);
        }

        public void CopyIn_XML(
            string path,
            out GameSetting_ErrorMask errorMask,
            NotifyingFireParameters? cmds = null)
        {
            var root = XDocument.Load(path).Root;
            this.CopyIn_XML(
                root: root,
                errorMask: out errorMask,
                cmds: cmds);
        }

        public void CopyIn_XML(
            Stream stream,
            NotifyingFireParameters? cmds = null)
        {
            var root = XDocument.Load(stream).Root;
            this.CopyIn_XML(
                root: root,
                cmds: cmds);
        }

        public void CopyIn_XML(
            Stream stream,
            out GameSetting_ErrorMask errorMask,
            NotifyingFireParameters? cmds = null)
        {
            var root = XDocument.Load(stream).Root;
            this.CopyIn_XML(
                root: root,
                errorMask: out errorMask,
                cmds: cmds);
        }

        public override void CopyIn_XML(
            XElement root,
            out MajorRecord_ErrorMask errorMask,
            NotifyingFireParameters? cmds = null)
        {
            this.CopyIn_XML(
                root: root,
                errorMask: out GameSetting_ErrorMask errMask,
                cmds: cmds);
            errorMask = errMask;
        }

        #endregion

        #region XML Write
        public virtual void Write_XML(
            XmlWriter writer,
            out GameSetting_ErrorMask errorMask,
            string name = null)
        {
            errorMask = (GameSetting_ErrorMask)this.Write_XML_Internal(
                writer: writer,
                name: name,
                doMasks: true);
        }

        public virtual void Write_XML(
            string path,
            out GameSetting_ErrorMask errorMask,
            string name = null)
        {
            using (var writer = new XmlTextWriter(path, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                Write_XML(
                    writer: writer,
                    name: name,
                    errorMask: out errorMask);
            }
        }

        public virtual void Write_XML(
            Stream stream,
            out GameSetting_ErrorMask errorMask,
            string name = null)
        {
            using (var writer = new XmlTextWriter(stream, Encoding.ASCII))
            {
                writer.Formatting = Formatting.Indented;
                writer.Indentation = 3;
                Write_XML(
                    writer: writer,
                    name: name,
                    errorMask: out errorMask);
            }
        }

        protected override object Write_XML_Internal(
            XmlWriter writer,
            bool doMasks,
            string name = null)
        {
            GameSettingCommon.Write_XML(
                writer: writer,
                item: this,
                doMasks: doMasks,
                errorMask: out var errorMask);
            return errorMask;
        }
        #endregion

        protected static void Fill_XML_Internal(
            GameSetting item,
            XElement root,
            string name,
            Func<GameSetting_ErrorMask> errorMask)
        {
            switch (name)
            {
                default:
                    MajorRecord.Fill_XML_Internal(
                        item: item,
                        root: root,
                        name: name,
                        errorMask: errorMask);
                    break;
            }
        }

        #endregion

        #region Binary Translation
        #region Binary Copy In
        public override void CopyIn_Binary(
            MutagenFrame frame,
            NotifyingFireParameters? cmds = null)
        {
            LoquiBinaryTranslation<GameSetting, GameSetting_ErrorMask>.Instance.CopyIn(
                frame: frame,
                item: this,
                skipProtected: true,
                doMasks: false,
                mask: out var errorMask,
                cmds: cmds);
        }

        public virtual void CopyIn_Binary(
            MutagenFrame frame,
            out GameSetting_ErrorMask errorMask,
            NotifyingFireParameters? cmds = null)
        {
            LoquiBinaryTranslation<GameSetting, GameSetting_ErrorMask>.Instance.CopyIn(
                frame: frame,
                item: this,
                skipProtected: true,
                doMasks: true,
                mask: out errorMask,
                cmds: cmds);
        }

        public void CopyIn_Binary(
            string path,
            NotifyingFireParameters? cmds = null)
        {
            using (var reader = new MutagenReader(path))
            {
                var frame = new MutagenFrame(reader);
                this.CopyIn_Binary(
                    frame: frame,
                    cmds: cmds);
            }
        }

        public void CopyIn_Binary(
            string path,
            out GameSetting_ErrorMask errorMask,
            NotifyingFireParameters? cmds = null)
        {
            using (var reader = new MutagenReader(path))
            {
                var frame = new MutagenFrame(reader);
                this.CopyIn_Binary(
                    frame: frame,
                    errorMask: out errorMask,
                    cmds: cmds);
            }
        }

        public void CopyIn_Binary(
            Stream stream,
            NotifyingFireParameters? cmds = null)
        {
            using (var reader = new MutagenReader(stream))
            {
                var frame = new MutagenFrame(reader);
                this.CopyIn_Binary(
                    frame: frame,
                    cmds: cmds);
            }
        }

        public void CopyIn_Binary(
            Stream stream,
            out GameSetting_ErrorMask errorMask,
            NotifyingFireParameters? cmds = null)
        {
            using (var reader = new MutagenReader(stream))
            {
                var frame = new MutagenFrame(reader);
                this.CopyIn_Binary(
                    frame: frame,
                    errorMask: out errorMask,
                    cmds: cmds);
            }
        }

        public override void CopyIn_Binary(
            MutagenFrame frame,
            out MajorRecord_ErrorMask errorMask,
            NotifyingFireParameters? cmds = null)
        {
            this.CopyIn_Binary(
                frame: frame,
                errorMask: out GameSetting_ErrorMask errMask,
                cmds: cmds);
            errorMask = errMask;
        }

        #endregion

        #region Binary Write
        public virtual void Write_Binary(
            MutagenWriter writer,
            out GameSetting_ErrorMask errorMask)
        {
            errorMask = (GameSetting_ErrorMask)this.Write_Binary_Internal(
                writer: writer,
                recordTypeConverter: null,
                doMasks: true);
        }

        public virtual void Write_Binary(
            string path,
            out GameSetting_ErrorMask errorMask)
        {
            using (var writer = new MutagenWriter(path))
            {
                Write_Binary(
                    writer: writer,
                    errorMask: out errorMask);
            }
        }

        public virtual void Write_Binary(
            Stream stream,
            out GameSetting_ErrorMask errorMask)
        {
            using (var writer = new MutagenWriter(stream))
            {
                Write_Binary(
                    writer: writer,
                    errorMask: out errorMask);
            }
        }

        protected override object Write_Binary_Internal(
            MutagenWriter writer,
            RecordTypeConverter recordTypeConverter,
            bool doMasks)
        {
            GameSettingCommon.Write_Binary(
                writer: writer,
                item: this,
                doMasks: doMasks,
                recordTypeConverter: recordTypeConverter,
                errorMask: out var errorMask);
            return errorMask;
        }
        #endregion

        #endregion

        public GameSetting Copy(
            GameSetting_CopyMask copyMask = null,
            IGameSettingGetter def = null)
        {
            return GameSetting.Copy(
                this,
                copyMask: copyMask,
                def: def);
        }

        public static GameSetting Copy(
            IGameSetting item,
            GameSetting_CopyMask copyMask = null,
            IGameSettingGetter def = null)
        {
            GameSetting ret = (GameSetting)System.Activator.CreateInstance(item.GetType());
            ret.CopyFieldsFrom(
                item,
                copyMask: copyMask,
                def: def);
            return ret;
        }

        public static CopyType CopyGeneric<CopyType>(
            CopyType item,
            GameSetting_CopyMask copyMask = null,
            IGameSettingGetter def = null)
            where CopyType : class, IGameSetting
        {
            CopyType ret = (CopyType)System.Activator.CreateInstance(item.GetType());
            ret.CopyFieldsFrom(
                item,
                copyMask: copyMask,
                doMasks: false,
                errorMask: null,
                cmds: null,
                def: def);
            return ret;
        }

        public static GameSetting Copy_ToLoqui(
            IGameSettingGetter item,
            GameSetting_CopyMask copyMask = null,
            IGameSettingGetter def = null)
        {
            GameSetting ret = (GameSetting)System.Activator.CreateInstance(item.GetType());
            ret.CopyFieldsFrom(
                item,
                copyMask: copyMask,
                def: def);
            return ret;
        }

        protected override void SetNthObject(ushort index, object obj, NotifyingFireParameters? cmds = null)
        {
            GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
            switch (enu)
            {
                default:
                    base.SetNthObject(index, obj, cmds);
                    break;
            }
        }

        public override void Clear(NotifyingUnsetParameters? cmds = null)
        {
            CallClearPartial_Internal(cmds);
            GameSettingCommon.Clear(this, cmds);
        }


        protected new static void CopyInInternal_GameSetting(GameSetting obj, KeyValuePair<ushort, object> pair)
        {
            if (!EnumExt.TryParse(pair.Key, out GameSetting_FieldIndex enu))
            {
                CopyInInternal_MajorRecord(obj, pair);
            }
            switch (enu)
            {
                default:
                    throw new ArgumentException($"Unknown enum type: {enu}");
            }
        }
        public static void CopyIn(IEnumerable<KeyValuePair<ushort, object>> fields, GameSetting obj)
        {
            ILoquiObjectExt.CopyFieldsIn(obj, fields, def: null, skipProtected: false, cmds: null);
        }

    }
    #endregion

    #region Interface
    public interface IGameSetting : IGameSettingGetter, IMajorRecord, ILoquiClass<IGameSetting, IGameSettingGetter>, ILoquiClass<GameSetting, IGameSettingGetter>
    {
    }

    public interface IGameSettingGetter : IMajorRecordGetter
    {

    }

    #endregion

}

namespace Mutagen.Bethesda.Oblivion.Internals
{
    #region Field Index
    public enum GameSetting_FieldIndex
    {
        MajorRecordFlags = 0,
        FormID = 1,
        Version = 2,
        EditorID = 3,
        RecordType = 4,
    }
    #endregion

    #region Registration
    public class GameSetting_Registration : ILoquiRegistration
    {
        public static readonly GameSetting_Registration Instance = new GameSetting_Registration();

        public static ProtocolKey ProtocolKey => ProtocolDefinition_Oblivion.ProtocolKey;

        public static readonly ObjectKey ObjectKey = new ObjectKey(
            protocolKey: ProtocolDefinition_Oblivion.ProtocolKey,
            msgID: 7,
            version: 0);

        public const string GUID = "6ce31534-6f55-4575-a914-20e70476f6ad";

        public const ushort FieldCount = 0;

        public static readonly Type MaskType = typeof(GameSetting_Mask<>);

        public static readonly Type ErrorMaskType = typeof(GameSetting_ErrorMask);

        public static readonly Type ClassType = typeof(GameSetting);

        public static readonly Type GetterType = typeof(IGameSettingGetter);

        public static readonly Type SetterType = typeof(IGameSetting);

        public static readonly Type CommonType = typeof(GameSettingCommon);

        public const string FullName = "Mutagen.Bethesda.Oblivion.GameSetting";

        public const string Name = "GameSetting";

        public const string Namespace = "Mutagen.Bethesda.Oblivion";

        public const byte GenericCount = 0;

        public static readonly Type GenericRegistrationType = null;

        public static ushort? GetNameIndex(StringCaseAgnostic str)
        {
            switch (str.Upper)
            {
                default:
                    return null;
            }
        }

        public static bool GetNthIsEnumerable(ushort index)
        {
            GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecord_Registration.GetNthIsEnumerable(index);
            }
        }

        public static bool GetNthIsLoqui(ushort index)
        {
            GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecord_Registration.GetNthIsLoqui(index);
            }
        }

        public static bool GetNthIsSingleton(ushort index)
        {
            GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecord_Registration.GetNthIsSingleton(index);
            }
        }

        public static string GetNthName(ushort index)
        {
            GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecord_Registration.GetNthName(index);
            }
        }

        public static bool IsNthDerivative(ushort index)
        {
            GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecord_Registration.IsNthDerivative(index);
            }
        }

        public static bool IsProtected(ushort index)
        {
            GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecord_Registration.IsProtected(index);
            }
        }

        public static Type GetNthType(ushort index)
        {
            GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecord_Registration.GetNthType(index);
            }
        }

        public static readonly RecordType GMST_HEADER = new RecordType("GMST");
        public static readonly RecordType TRIGGERING_RECORD_TYPE = GMST_HEADER;
        public const int NumStructFields = 0;
        public const int NumTypedFields = 0;
        #region Interface
        ProtocolKey ILoquiRegistration.ProtocolKey => ProtocolKey;
        ObjectKey ILoquiRegistration.ObjectKey => ObjectKey;
        string ILoquiRegistration.GUID => GUID;
        int ILoquiRegistration.FieldCount => FieldCount;
        Type ILoquiRegistration.MaskType => MaskType;
        Type ILoquiRegistration.ErrorMaskType => ErrorMaskType;
        Type ILoquiRegistration.ClassType => ClassType;
        Type ILoquiRegistration.SetterType => SetterType;
        Type ILoquiRegistration.GetterType => GetterType;
        Type ILoquiRegistration.CommonType => CommonType;
        string ILoquiRegistration.FullName => FullName;
        string ILoquiRegistration.Name => Name;
        string ILoquiRegistration.Namespace => Namespace;
        byte ILoquiRegistration.GenericCount => GenericCount;
        Type ILoquiRegistration.GenericRegistrationType => GenericRegistrationType;
        ushort? ILoquiRegistration.GetNameIndex(StringCaseAgnostic name) => GetNameIndex(name);
        bool ILoquiRegistration.GetNthIsEnumerable(ushort index) => GetNthIsEnumerable(index);
        bool ILoquiRegistration.GetNthIsLoqui(ushort index) => GetNthIsLoqui(index);
        bool ILoquiRegistration.GetNthIsSingleton(ushort index) => GetNthIsSingleton(index);
        string ILoquiRegistration.GetNthName(ushort index) => GetNthName(index);
        bool ILoquiRegistration.IsNthDerivative(ushort index) => IsNthDerivative(index);
        bool ILoquiRegistration.IsProtected(ushort index) => IsProtected(index);
        Type ILoquiRegistration.GetNthType(ushort index) => GetNthType(index);
        #endregion

    }
    #endregion

    #region Extensions
    public static partial class GameSettingCommon
    {
        #region Copy Fields From
        public static void CopyFieldsFrom(
            this IGameSetting item,
            IGameSettingGetter rhs,
            GameSetting_CopyMask copyMask = null,
            IGameSettingGetter def = null,
            NotifyingFireParameters? cmds = null)
        {
            GameSettingCommon.CopyFieldsFrom(
                item: item,
                rhs: rhs,
                def: def,
                doMasks: false,
                errorMask: null,
                copyMask: copyMask,
                cmds: cmds);
        }

        public static void CopyFieldsFrom(
            this IGameSetting item,
            IGameSettingGetter rhs,
            out GameSetting_ErrorMask errorMask,
            GameSetting_CopyMask copyMask = null,
            IGameSettingGetter def = null,
            NotifyingFireParameters? cmds = null)
        {
            GameSettingCommon.CopyFieldsFrom(
                item: item,
                rhs: rhs,
                def: def,
                doMasks: true,
                errorMask: out errorMask,
                copyMask: copyMask,
                cmds: cmds);
        }

        public static void CopyFieldsFrom(
            this IGameSetting item,
            IGameSettingGetter rhs,
            IGameSettingGetter def,
            bool doMasks,
            out GameSetting_ErrorMask errorMask,
            GameSetting_CopyMask copyMask,
            NotifyingFireParameters? cmds)
        {
            GameSetting_ErrorMask retErrorMask = null;
            Func<GameSetting_ErrorMask> maskGetter = () =>
            {
                if (retErrorMask == null)
                {
                    retErrorMask = new GameSetting_ErrorMask();
                }
                return retErrorMask;
            };
            CopyFieldsFrom(
                item: item,
                rhs: rhs,
                def: def,
                doMasks: true,
                errorMask: maskGetter,
                copyMask: copyMask,
                cmds: cmds);
            errorMask = retErrorMask;
        }

        public static void CopyFieldsFrom(
            this IGameSetting item,
            IGameSettingGetter rhs,
            IGameSettingGetter def,
            bool doMasks,
            Func<GameSetting_ErrorMask> errorMask,
            GameSetting_CopyMask copyMask,
            NotifyingFireParameters? cmds)
        {
            MajorRecordCommon.CopyFieldsFrom(
                item,
                rhs,
                def,
                doMasks,
                errorMask,
                copyMask,
                cmds);
        }

        #endregion

        public static void SetNthObjectHasBeenSet(
            ushort index,
            bool on,
            IGameSetting obj,
            NotifyingFireParameters? cmds = null)
        {
            GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
            switch (enu)
            {
                default:
                    MajorRecordCommon.SetNthObjectHasBeenSet(index, on, obj);
                    break;
            }
        }

        public static void UnsetNthObject(
            ushort index,
            IGameSetting obj,
            NotifyingUnsetParameters? cmds = null)
        {
            GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
            switch (enu)
            {
                default:
                    MajorRecordCommon.UnsetNthObject(index, obj);
                    break;
            }
        }

        public static bool GetNthObjectHasBeenSet(
            ushort index,
            IGameSetting obj)
        {
            GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecordCommon.GetNthObjectHasBeenSet(index, obj);
            }
        }

        public static object GetNthObject(
            ushort index,
            IGameSettingGetter obj)
        {
            GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
            switch (enu)
            {
                default:
                    return MajorRecordCommon.GetNthObject(index, obj);
            }
        }

        public static void Clear(
            IGameSetting item,
            NotifyingUnsetParameters? cmds = null)
        {
        }

        public static GameSetting_Mask<bool> GetEqualsMask(
            this IGameSettingGetter item,
            IGameSettingGetter rhs)
        {
            var ret = new GameSetting_Mask<bool>();
            FillEqualsMask(item, rhs, ret);
            return ret;
        }

        public static void FillEqualsMask(
            IGameSettingGetter item,
            IGameSettingGetter rhs,
            GameSetting_Mask<bool> ret)
        {
            if (rhs == null) return;
            MajorRecordCommon.FillEqualsMask(item, rhs, ret);
        }

        public static string ToString(
            this IGameSettingGetter item,
            string name = null,
            GameSetting_Mask<bool> printMask = null)
        {
            var fg = new FileGeneration();
            item.ToString(fg, name, printMask);
            return fg.ToString();
        }

        public static void ToString(
            this IGameSettingGetter item,
            FileGeneration fg,
            string name = null,
            GameSetting_Mask<bool> printMask = null)
        {
            if (name == null)
            {
                fg.AppendLine($"{nameof(GameSetting)} =>");
            }
            else
            {
                fg.AppendLine($"{name} ({nameof(GameSetting)}) =>");
            }
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
            }
            fg.AppendLine("]");
        }

        public static bool HasBeenSet(
            this IGameSettingGetter item,
            GameSetting_Mask<bool?> checkMask)
        {
            return true;
        }

        public static GameSetting_Mask<bool> GetHasBeenSetMask(IGameSettingGetter item)
        {
            var ret = new GameSetting_Mask<bool>();
            return ret;
        }

        public static GameSetting_FieldIndex? ConvertFieldIndex(MajorRecord_FieldIndex? index)
        {
            if (!index.HasValue) return null;
            return ConvertFieldIndex(index: index.Value);
        }

        public static GameSetting_FieldIndex ConvertFieldIndex(MajorRecord_FieldIndex index)
        {
            switch (index)
            {
                case MajorRecord_FieldIndex.MajorRecordFlags:
                    return (GameSetting_FieldIndex)((int)index);
                case MajorRecord_FieldIndex.FormID:
                    return (GameSetting_FieldIndex)((int)index);
                case MajorRecord_FieldIndex.Version:
                    return (GameSetting_FieldIndex)((int)index);
                case MajorRecord_FieldIndex.EditorID:
                    return (GameSetting_FieldIndex)((int)index);
                case MajorRecord_FieldIndex.RecordType:
                    return (GameSetting_FieldIndex)((int)index);
                default:
                    throw new ArgumentException($"Index is out of range: {index.ToStringFast_Enum_Only()}");
            }
        }

        #region XML Translation
        #region XML Write
        public static void Write_XML(
            XmlWriter writer,
            IGameSettingGetter item,
            bool doMasks,
            out GameSetting_ErrorMask errorMask,
            string name = null)
        {
            GameSetting_ErrorMask errMaskRet = null;
            Write_XML_Internal(
                writer: writer,
                name: name,
                item: item,
                errorMask: doMasks ? () => errMaskRet ?? (errMaskRet = new GameSetting_ErrorMask()) : default(Func<GameSetting_ErrorMask>));
            errorMask = errMaskRet;
        }

        private static void Write_XML_Internal(
            XmlWriter writer,
            IGameSettingGetter item,
            Func<GameSetting_ErrorMask> errorMask,
            string name = null)
        {
            try
            {
                using (new ElementWrapper(writer, name ?? "Mutagen.Bethesda.Oblivion.GameSetting"))
                {
                    if (name != null)
                    {
                        writer.WriteAttributeString("type", "Mutagen.Bethesda.Oblivion.GameSetting");
                    }
                }
            }
            catch (Exception ex)
            when (errorMask != null)
            {
                errorMask().Overall = ex;
            }
        }
        #endregion

        #endregion

        #region Binary Translation
        #region Binary Write
        public static void Write_Binary(
            MutagenWriter writer,
            GameSetting item,
            RecordTypeConverter recordTypeConverter,
            bool doMasks,
            out GameSetting_ErrorMask errorMask)
        {
            GameSetting_ErrorMask errMaskRet = null;
            Write_Binary_Internal(
                writer: writer,
                item: item,
                recordTypeConverter: recordTypeConverter,
                errorMask: doMasks ? () => errMaskRet ?? (errMaskRet = new GameSetting_ErrorMask()) : default(Func<GameSetting_ErrorMask>));
            errorMask = errMaskRet;
        }

        private static void Write_Binary_Internal(
            MutagenWriter writer,
            GameSetting item,
            RecordTypeConverter recordTypeConverter,
            Func<GameSetting_ErrorMask> errorMask)
        {
            try
            {
                using (HeaderExport.ExportHeader(
                    writer: writer,
                    record: GameSetting_Registration.GMST_HEADER,
                    type: ObjectType.Record))
                {
                    MajorRecordCommon.Write_Binary_Embedded(
                        item: item,
                        writer: writer,
                        errorMask: errorMask);
                    MajorRecordCommon.Write_Binary_RecordTypes(
                        item: item,
                        writer: writer,
                        recordTypeConverter: recordTypeConverter,
                        errorMask: errorMask);
                }
            }
            catch (Exception ex)
            when (errorMask != null)
            {
                errorMask().Overall = ex;
            }
        }
        #endregion

        #endregion

    }
    #endregion

    #region Modules

    #region Mask
    public class GameSetting_Mask<T> : MajorRecord_Mask<T>, IMask<T>, IEquatable<GameSetting_Mask<T>>
    {
        #region Ctors
        public GameSetting_Mask()
        {
        }

        public GameSetting_Mask(T initialValue)
        {
        }
        #endregion

        #region Equals
        public override bool Equals(object obj)
        {
            if (!(obj is GameSetting_Mask<T> rhs)) return false;
            return Equals(rhs);
        }

        public bool Equals(GameSetting_Mask<T> rhs)
        {
            if (rhs == null) return false;
            if (!base.Equals(rhs)) return false;
            return true;
        }
        public override int GetHashCode()
        {
            int ret = 0;
            ret = ret.CombineHashCode(base.GetHashCode());
            return ret;
        }

        #endregion

        #region All Equal
        public override bool AllEqual(Func<T, bool> eval)
        {
            if (!base.AllEqual(eval)) return false;
            return true;
        }
        #endregion

        #region Translate
        public new GameSetting_Mask<R> Translate<R>(Func<T, R> eval)
        {
            var ret = new GameSetting_Mask<R>();
            this.Translate_InternalFill(ret, eval);
            return ret;
        }

        protected void Translate_InternalFill<R>(GameSetting_Mask<R> obj, Func<T, R> eval)
        {
            base.Translate_InternalFill(obj, eval);
        }
        #endregion

        #region Clear Enumerables
        public override void ClearEnumerables()
        {
            base.ClearEnumerables();
        }
        #endregion

        #region To String
        public override string ToString()
        {
            return ToString(printMask: null);
        }

        public string ToString(GameSetting_Mask<bool> printMask = null)
        {
            var fg = new FileGeneration();
            ToString(fg, printMask);
            return fg.ToString();
        }

        public void ToString(FileGeneration fg, GameSetting_Mask<bool> printMask = null)
        {
            fg.AppendLine($"{nameof(GameSetting_Mask<T>)} =>");
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
            }
            fg.AppendLine("]");
        }
        #endregion

    }

    public class GameSetting_ErrorMask : MajorRecord_ErrorMask, IErrorMask<GameSetting_ErrorMask>
    {
        #region IErrorMask
        public override void SetNthException(int index, Exception ex)
        {
            GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
            switch (enu)
            {
                default:
                    base.SetNthException(index, ex);
                    break;
            }
        }

        public override void SetNthMask(int index, object obj)
        {
            GameSetting_FieldIndex enu = (GameSetting_FieldIndex)index;
            switch (enu)
            {
                default:
                    base.SetNthMask(index, obj);
                    break;
            }
        }

        public override bool IsInError()
        {
            if (Overall != null) return true;
            return false;
        }
        #endregion

        #region To String
        public override string ToString()
        {
            var fg = new FileGeneration();
            ToString(fg);
            return fg.ToString();
        }

        public override void ToString(FileGeneration fg)
        {
            fg.AppendLine("GameSetting_ErrorMask =>");
            fg.AppendLine("[");
            using (new DepthWrapper(fg))
            {
                if (this.Overall != null)
                {
                    fg.AppendLine("Overall =>");
                    fg.AppendLine("[");
                    using (new DepthWrapper(fg))
                    {
                        fg.AppendLine($"{this.Overall}");
                    }
                    fg.AppendLine("]");
                }
                ToString_FillInternal(fg);
            }
            fg.AppendLine("]");
        }
        protected override void ToString_FillInternal(FileGeneration fg)
        {
            base.ToString_FillInternal(fg);
        }
        #endregion

        #region Combine
        public GameSetting_ErrorMask Combine(GameSetting_ErrorMask rhs)
        {
            var ret = new GameSetting_ErrorMask();
            return ret;
        }
        public static GameSetting_ErrorMask Combine(GameSetting_ErrorMask lhs, GameSetting_ErrorMask rhs)
        {
            if (lhs != null && rhs != null) return lhs.Combine(rhs);
            return lhs ?? rhs;
        }
        #endregion

    }
    public class GameSetting_CopyMask : MajorRecord_CopyMask
    {
    }
    #endregion




    #endregion

}
