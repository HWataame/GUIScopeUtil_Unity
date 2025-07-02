/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
値が複数あるフラグを変更するスコープ

MixedValueScope.cs
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
    /// 値が複数あるフラグを変更するスコープ
    /// </summary>
    public struct MixedValueScope : IDisposable
    {
        /// <summary>
        /// このスコープが有効か
        /// </summary>
        private bool isValid;
        /// <summary>
        /// スコープ開始前の値が複数あるフラグ
        /// </summary>
        private readonly bool originalMixed;


        /// <summary>
        /// 値が複数あるフラグを変更するスコープを開始する
        /// </summary>
        /// <param name="isMixed">値が複数あるか</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public MixedValueScope(bool isMixed)
        {
            // スコープ開始前の値が複数あるフラグを保持する
            originalMixed = EditorGUI.showMixedValue;

            // 値が複数あるフラグを設定する
            EditorGUI.showMixedValue = isMixed;

            // 有効フラグを立てる
            isValid = true;
        }

        /// <summary>
        /// 値が複数あるフラグを変更するスコープを開始する
        /// </summary>
        /// <param name="property">プロパティ</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MixedValueScope BeginScope(SerializedProperty property)
        {
            // 引数がnullである場合は失敗
            if (property == null) return default;

            // プロパティの状態を使用してスコープを開始する
            return new(property.hasMultipleDifferentValues);
        }

        /// <summary>
        /// 値が複数あるフラグを変更するスコープを開始する
        /// </summary>
        /// <param name="property">プロパティ</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static MixedValueScope BeginScope(MaterialProperty property)
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

            // 値が複数あるフラグを復元する
            EditorGUI.showMixedValue = originalMixed;

            // 有効フラグをクリアする
            isValid = false;
        }
    }
}
