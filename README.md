# GUI Scopes for Unity Editor
## 概要
UnityエディターのGUI機能向けのスコープです

## 使用方法
### ラベル幅を一時的に変更する
```csharp
using (new LabelWidthScope(80))
{
    // このスコープの中にラベルを持つGUIコントロールの描画処理を記述する

}
```
例：

![ラベル幅](https://github.com/user-attachments/assets/410476ca-eb6d-4b93-b7be-b2c25cf111c7)

### 値が複数種類存在するフラグを一時的に変更する
```csharp
using (new MixedValueScope(isMixed))
{
    // このスコープの中にラベルを持つGUIコントロールの描画処理を記述する

}
```
```csharp
// シリアル化されたフィールドのプロパティから複数種類存在するかの状態を渡すこともできる
using (MixedValueScope.BeginScope(serializedProperty))
{
    // このスコープの中にラベルを持つGUIコントロールの描画処理を記述する

}
```
```csharp
// 上のものに加え、GUIの変更検知を行うこともできる
using (var change = MixedChangeCheckScope.BeginScope(serializedProperty))
{
    // このスコープの中にラベルを持つGUIコントロールの描画処理を記述する
    
    if (change.IsChanged)
    {
        // 変更を検知した時の処理を記述する

    }
}
```
例：

![複数種類の値](https://github.com/user-attachments/assets/3acb2510-8be9-4ad3-bbf8-5b18c3648679)

シリアル化されるフィールドに`[FieldDisplayName(表示名)]`属性を付与すると、インスペクター上の表示が変化します / Attaching a `[FieldDisplayName(displayName)]`attribute to a field will change its display in Inspector

## 導入方法 / English "How to introduction" is below this
1. Gitをインストールする
2. 追加したいプロジェクトを開き、Package Managerを開く
3. 以下の文字列をコピー、またはこのページ上部の「<> Code」からClone URLをコピーする

    https://github.com/HWataame/GUIScopeUtil_Unity.git
4. 「Package Manager」ウィンドウの左上の「＋」ボタンをクリックし、「Install package from git URL...」を選択する

    ![導入方法01](https://github.com/user-attachments/assets/60b039b5-33a0-4239-9e62-c2418ff48867)
5. 入力欄に手順2でコピーしたURLを貼り付け、「Install」ボタンを押す

    ![導入方法02](https://github.com/user-attachments/assets/0cd77d52-73f9-4aa8-98ce-24dcbceec2e9)
6. (必要に応じて)Assembly Definition Assetの管理下のコードで利用する場合は、`HW.GUIScopes.Editor`をAssembly Definition Referencesに追加する
    
    ![導入方法03(必要に応じて)](https://github.com/user-attachments/assets/ee3e9f33-1068-43bd-bfd0-f74b098b75fc)


## How to introduction / 日本語の「導入方法」は上にあります
1. Install Git to your computer.
2. Open Package Manager in the Unity project to which you want to add this feature.
3. Copy the following string, or copy the Clone URL from "<> Code" at the top of this page

    https://github.com/HWataame/GUIScopeUtil_Unity.git
4. Click the "+" button in the "Package Manager" window and select "Install package from git URL...".

    ![導入方法01](https://github.com/user-attachments/assets/60b039b5-33a0-4239-9e62-c2418ff48867)
5. Paste the URL copied in Step 2 into the input field and press the "Install" button.

    ![導入方法02](https://github.com/user-attachments/assets/0cd77d52-73f9-4aa8-98ce-24dcbceec2e9)
6. (If necessary) For use in code under the control of Assembly Definition Asset...

   Add `HW.GUIScopes.Editor` to "Assembly Definition References" in your Assembly Definition Asset.
   
    ![導入方法03(必要に応じて)](https://github.com/user-attachments/assets/ee3e9f33-1068-43bd-bfd0-f74b098b75fc)

## ライセンス / License
MITライセンスです / Using "MIT license"

[LISENCE](/LICENSE)
