namespace MowingPlanetCompany
{
    /// <summary>
    /// animator state machineのステート一覧
    /// </summary>
    public enum AnimState
    {
        RightAttack, LeftAttack, UpperAttack, Jump
    }

    /// <summary>
    /// animator controllerのパラメータ一覧
    /// </summary>
    public enum AnimParameter
    {
        Speed, Attack, IsRunning, IsGrounded
    }
}
