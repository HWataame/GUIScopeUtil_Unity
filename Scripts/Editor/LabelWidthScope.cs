/*
━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━
ラベルの幅を変更するスコープ

LabelWidthScope.cs
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
    /// ラベルの幅を変更するスコープ
    /// </summary>
    public struct LabelWidthScope : IDisposable
    {
        /// <summary>
        /// このスコープが有効か
        /// </summary>
        private bool isValid;
        /// <summary>
        /// スコープ開始前のラベルの幅
        /// </summary>
        private readonly float originalWidth;


        /// <summary>
        /// ラベルの幅を変更するスコープを開始する
        /// </summary>
        /// <param name="labelWidth">ラベルの幅</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public LabelWidthScope(float labelWidth)
        {
            // スコープ開始前のラベルの幅を保持する
            originalWidth = EditorGUIUtility.labelWidth;

            // ラベルの幅を設定する
            EditorGUIUtility.labelWidth = labelWidth;

            // 有効フラグを立てる
            isValid = true;
        }

        /// <summary>
        /// 最低限のラベルの幅のスコープを開始する
        /// </summary>
        /// <returns>スコープ</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static LabelWidthScope NoWidth()
        {
            return new(float.Epsilon);
        }

        /// <summary>
        /// スコープを終了する
        /// </summary>
        public void Dispose()
        {
            // 有効フラグが立っていない場合は何もしない
            if (!isValid) return;

            // ラベルの幅を復元する
            EditorGUIUtility.labelWidth = originalWidth;

            // 有効フラグをクリアする
            isValid = false;
        }
    }
}
