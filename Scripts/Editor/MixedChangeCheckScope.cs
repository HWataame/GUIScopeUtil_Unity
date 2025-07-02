/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
値が複数あるフラグを変更し、変更を検知するスコープ

MixedChangeCheckScope.cs
────────────────────────────────────────
バージョン: 1.0.0
2025 Wataame(HWataame)
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
*/
using System;
using System.Runtime.CompilerServices;
using UnityEditor;

namespace HW.GUIScopes
{
    /// <summary>
    /// 値が複数あるフラグを変更し、変更を検知するスコープ
    /// </summary>
    public struct MixedChangeCheckScope : IDisposable
    {
        /// <summary>
        /// このスコープが有効か
        /// </summary>
        private bool isValid;
        /// <summary>
        /// 値が複数あるフラグを変更するスコープ
        /// </summary>
        private MixedValueScope mixedValue;
        /// <summary>
        /// 変更を検知するスコープ
        /// </summary>
        private EditorGUI.ChangeCheckScope change;

        /// <summary>
        /// スコープ内で変更があったか
        /// </summary>
        public readonly bool IsChanged
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => isValid && change.changed;
        }


        /// <summary>
        /// 値が複数あるフラグを変更し、変更を検知するスコープを開始する
        /// </summary>
        /// <param name="isMixed">値が複数あるか</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MixedChangeCheckScope(bool isMixed)
        {
            // 値が複数あるフラグを変更するスコープを開始する
            mixedValue = new(isMixed);

            // 値の変更を検知するスコープを開始する
            change = new();

            // 値が複数あるフラグを設定する
            EditorGUI.showMixedValue = isMixed;

            // 有効フラグを立てる
            isValid = true;
        }

        /// <summary>
        /// 値が複数あるフラグを変更し、変更を検知するスコープを開始する
        /// </summary>
        /// <param name="property">プロパティ</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MixedChangeCheckScope BeginScope(SerializedProperty property)
        {
            // 引数がnullである場合は失敗
            if (property == null) return default;

            // プロパティの状態を使用してスコープを開始する
            return new(property.hasMultipleDifferentValues);
        }

        /// <summary>
        /// 値が複数あるフラグを変更し、変更を検知するスコープを開始する
        /// </summary>
        /// <param name="property">プロパティ</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MixedChangeCheckScope BeginScope(MaterialProperty property)
        {
            // 引数がnullである場合は失敗
            if (property == null) return default;

            // プロパティの状態を使用してスコープを開始する
            return new(property.hasMixedValue);
        }

        /// <summary>
        /// スコープを終了する
        /// </summary>
        public void Dispose()
        {
            // 有効フラグが立っていない場合は何もしない
            if (!isValid) return;

            // 値の変更を検知するスコープを終了する
            change.Dispose();
            change = null;

            // 値が複数あるフラグを変更するスコープを終了する
            mixedValue.Dispose();
            mixedValue = default;

            // 有効フラグをクリアする
            isValid = false;
        }
    }
}
